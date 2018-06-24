using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Noticias.Models
{
    public class Categorias
    {
        public Categorias() {
            Noticias = new HashSet<Noticias>();
        }

        [Key]
        public int CategoriaID { get; set; }
        
        public string Nome { get; set; }

        public ICollection<Noticias> Noticias { get; set; }
    }
}