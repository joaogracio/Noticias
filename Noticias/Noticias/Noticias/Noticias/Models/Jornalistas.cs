using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Noticias.Models
{
    public class Jornalistas
    {
        public Jornalistas() {
            Noticias = new HashSet<Noticias>();
        }

        public int JornalistasID { get; set; }

        public string Nome { get; set; }

        public ICollection<Noticias> Noticias { get; set; }
    }
}