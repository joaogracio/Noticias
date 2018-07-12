using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Noticias.Models
{
    public class Noticias
    {
        private Noticias model;

        public Noticias() {
            Imagens = new HashSet<ImagensNova>();
        }

        public Noticias(Noticias model)
        {
            this.model = model;
        }

        [Key]
        public int NoticiasID { get; set; }

        public string Resumo { get; set; }

        public string Texto { get; set; }

        public string Titulo { get; set; }

        public DateTime Data { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaFK { get; set; }

        // Relaciona uma Noticia com uma Categoria
        public Categorias Categoria { get; set; }

        [ForeignKey("Jornalista")]
        public int JornalistaFK { get; set; }

        public virtual Jornalistas Jornalista { get; set; }

        //[ForeignKey("Fotografo")]
        //public int FotografiaFK { get; set; }

        //public Fotografos Fotografo { get; set; }

        public virtual ICollection<ImagensNova> Imagens { get; set; }

    }
}