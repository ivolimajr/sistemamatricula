﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sistemaMatricula.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ValidaSenha : ValidationAttribute
    {

        private sistemaMatriculaDesktop db = new sistemaMatriculaDesktop();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var loginBanco = db.usuario.FirstOrDefault(p => p.senha == value.ToString().Trim());

            if (loginBanco == null)
                return new ValidationResult("Senha incorreta");
                     
           return ValidationResult.Success;
           
        }

    }

}