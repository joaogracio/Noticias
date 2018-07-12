using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Noticias.Models
{
    public class ImagensNova
    {
        [Key]
        public int ImagemID { get; set; }

        public string Descricao { get; set; }

        public string Tipo { get; set; }

        public string Directorio { get; set; }

        [ForeignKey("Noticia")]
        public int NoticiaFK { get; set; }

        public Noticias Noticia { get; set; }

    }
}