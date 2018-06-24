using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Noticias.ApiViewModels
{
    public class CreateNoticiaViewModel : IValidatableObject
    {
        [Required]
        public string Resumo { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public DateTime Data { get; set; }

        // Relaciona uma Noticia com uma Categoria
        public int CategoriaFK { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}