using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Noticias.Models
{
    public class Fotografos
    {
        public Fotografos() {
            Noticias = new HashSet<Noticias>();
        }
        [Key]
        public int FotografosID { get; set; }

        public string Nome { get; set; }

        public ICollection<Noticias> Noticias { get; set; }
    }
}