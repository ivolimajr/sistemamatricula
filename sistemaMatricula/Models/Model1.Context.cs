﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sistemaMatriculaDesktop : DbContext
    {
        public sistemaMatriculaDesktop()
            : base("name=sistemaMatriculaDesktop")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<aluno> aluno { get; set; }
        public virtual DbSet<contato> contato { get; set; }
        public virtual DbSet<disciplina> disciplina { get; set; }
        public virtual DbSet<endereco> endereco { get; set; }
        public virtual DbSet<funcionario> funcionario { get; set; }
        public virtual DbSet<turma> turma { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    }
}