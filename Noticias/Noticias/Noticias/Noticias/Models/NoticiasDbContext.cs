using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Noticias.Models
{
    public class NoticiasDbContext: DbContext
    {
        public NoticiasDbContext() : base("NoticiasDbContext")
        {

        }

        // Instrucoes para criar a tabela dentro da base de dados
        public virtual DbSet<Noticias> Noticia { get; set; }
        //public virtual DbSet<Fotografos> Fotografo { get; set; }
        public virtual DbSet<Jornalistas> Jornalista { get; set; }
        public virtual DbSet<Imagens> Imagem { get; set; }
        public virtual DbSet<Categorias> Categoria { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }
}