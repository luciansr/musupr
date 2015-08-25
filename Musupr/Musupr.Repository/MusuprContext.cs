using Musupr.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Musupr.Repository
{
    public class MusuprContext : DbContext
    {
        public MusuprContext()
            : base("name=MusuprDBConn")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusuprContext, Musupr.Repository.Migrations.Configuration>("MusuprDBConn"));
        }

        public void Save()
        {
            base.SaveChanges();
        }

        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoVaga> TiposVaga { get; set; }
        public DbSet<Qualificacao> Qualificacoes { get; set; }
        public DbSet<NivelQualificacao> NiveisQualificacao { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avaliacao>().HasRequired(a => a.vaga).WithMany(v => v.avaliacoes).WillCascadeOnDelete(false);
            modelBuilder.Entity<Avaliacao>().HasRequired(a => a.usuario).WithMany(v => v.avaliacoes).WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }
    }
}
