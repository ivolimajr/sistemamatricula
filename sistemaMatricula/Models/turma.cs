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
    
    public partial class turma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public turma()
        {
            this.aluno = new HashSet<aluno>();
        }
    
        public int id { get; set; }
        public int disciplina_id { get; set; }
        public int funcionario_id { get; set; }
        public string nome { get; set; }
        public string sala { get; set; }
        public bool situacao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aluno> aluno { get; set; }
        public virtual disciplina disciplina { get; set; }
        public virtual funcionario funcionario { get; set; }
    }
}
