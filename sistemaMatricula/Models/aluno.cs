//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sistemaMatricula.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class aluno
    {
        public int id { get; set; }
        public int turma_id { get; set; }
        public int endereco_id { get; set; }
        public int contato_id { get; set; }


        [Required(ErrorMessage = "Campo Necess�rio")]
        public string nomeAluno { get; set; }


        [Required(ErrorMessage = "Campo Necess�rio")]
        public string nomeResponsavel { get; set; }


        [Required(ErrorMessage = "Campo Necess�rio")]
        public string cpfAluno { get; set; }


        [Required(ErrorMessage = "Campo Necess�rio")]
        public string cpfResponsavel { get; set; }


        [Required(ErrorMessage = "Campo Necess�rio")]
        public string sexo { get; set; }


        [Required(ErrorMessage = "Campo Necess�rio")]
        public System.DateTime dataNascimento { get; set; }


        [Required(ErrorMessage = "Campo Necess�rio")]
        public System.DateTime dataMatricula { get; set; }

        public Nullable<System.DateTime> dataSaida { get; set; }


        [Required(ErrorMessage = "Campo Necess�rio")]
        public string matricula { get; set; }


        public string beneficios { get; set; }
        public string restricoes { get; set; }
        public bool situacao { get; set; }

        public virtual contato contato { get; set; }
        public virtual endereco endereco { get; set; }
        public virtual turma turma { get; set; }
    }
}