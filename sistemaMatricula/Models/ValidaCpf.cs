using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sistemaMatricula.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ValidaCpf : ValidationAttribute
    {

        //LIMPA OS CAMPOS DO CPF
        private static string RemoveNaoNumericos(object value)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string ret = reg.Replace(value.ToString(), string.Empty);
            return ret;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            //Remove formatação do número, ex: "123.456.789-01" vira: "12345678901"
            string cpf = RemoveNaoNumericos(value.ToString());
            if (cpf.Length > 11)
                return new ValidationResult("CPF Inválido");
            while (cpf.Length != 11)
                cpf = '0' + cpf;
            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    return new ValidationResult("CPF Inválido");
            if (igual || cpf == "12345678909")
                return new ValidationResult("CPF Inválido");
            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];
            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return new ValidationResult("CPF Inválido");
            }
            else if (numeros[9] != 11 - resultado)
                return new ValidationResult("CPF Inválido");
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];
            resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return new ValidationResult("CPF Inválido");
            }
            else
            if (numeros[10] != 11 - resultado)
                return new ValidationResult("CPF Inválido");
            return ValidationResult.Success;
        }

    }
    
}