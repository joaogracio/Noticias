using Noticias.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Noticias.Api
{
    public class CategoriasController : ApiController
    {
        #region Base de Dados

        // Referência para a base de dados.
        private Models.NoticiasDbContext db = new Models.NoticiasDbContext();

        #endregion

        // GET: api/Categorias
        public IHttpActionResult Get()
        {
            var categoria = db.Categoria.
                Select(cat => new
                {
                    cat.CategoriaID,
                    cat.Nome,
                }).
                ToList();

            return Ok(categoria);
        }

        // GET: api/Categorias/5
        public IHttpActionResult Get(int id)
        {
            Models.Noticias noticias = db.Noticia.Find(id);
            if (noticias == null)
            {
                return NotFound();
            }

            var categoria = db.Categoria.
                Select(cat => new
                {
                    cat.CategoriaID,
                    cat.Nome,
                }).
                Where(catg => catg.CategoriaID == id).
                ToList();

            return Ok(categoria);
        }

        // POST: api/Categorias
        public IHttpActionResult Post([FromBody] Categorias model)
        {
            if (!ModelState.IsValid)
            {
                // O BadRequest permite usar o ModelState
                // para informar o cliente dos erros de validação
                // tal como no MVC.
                return BadRequest(ModelState);
            }
            // Para determinar o ID da proxima noticia
            var ID = db.Categoria.Select(id => id.CategoriaID).Max() + 1;

            var categoria = new Categorias {
                CategoriaID = ID,
                Nome = model.Nome,
            };

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException exp)
            {

                // Seria muito provável que o método
                // db.Agentes.Max(agente => agente.ID) + 1
                // fizesse com que este if resultasse no Conflict (HTTP 409).
                if (db.Noticia.Count(e => e.NoticiasID == ID) > 0)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = categoria.CategoriaID }, categoria);
        }

        // PUT: api/Categorias/5
        public IHttpActionResult Put(int id, [FromBody] Categorias model)
        {
            if (!ModelState.IsValid)
            {
                // O BadRequest permite usar o ModelState
                // para informar o cliente dos erros de validaçãow
                // tal como no MVC.
                return BadRequest(ModelState);
            }

            // Verificar se existe referencia para este id
            if (id > db.Noticia.Select(not => not.NoticiasID).Max())
            {
                return BadRequest("Sorry, seems something wrong. Couldn't determine record to update.");
            }

            var categoria = (from cat in db.Categoria
                             where cat.CategoriaID == id
                             select cat).FirstOrDefault();

            categoria.Nome = categoria.Nome;

            db.Entry(categoria);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                if (!(db.Categoria.Count(e => e.CategoriaID == id) > 0))
                {
                    return NotFound();
                }
                else
                {
                    throw exp;
                }
            }

            return Ok(model);
        }

        // DELETE: api/Categorias/5
        public IHttpActionResult Delete(int id)
        {
            if ((db.Noticia.Select(not => not.NoticiasID == id) != null))
            {
                return BadRequest("Sorry, seems something wrong. Couldn't determine record to update.");
            }

            var categoria = (from cat in db.Categoria
                             where cat.CategoriaID == id
                             select cat).FirstOrDefault();

            db.Categoria.Remove(categoria);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                if (!(db.Categoria.Count(e => e.CategoriaID == id) > 0))
                {
                    return NotFound();
                }
                else
                {
                    throw exp;
                }
            }

            return Ok();
        }
    }
}
