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

    public partial class usuario
    {
        public int id { get; set; }
        public int funcionario_id { get; set; }
        public string login { get; set; }
        [Required(ErrorMessage = "Campo Necessário")]
        [DataType(DataType.Password)]
        public string senha { get; set; }
        public System.DateTime dataCriacao { get; set; }
        public bool situacao { get; set; }
        public string LoginErrorMessage { get; set; }
        public virtual funcionario funcionario { get; set; }
    }
}
