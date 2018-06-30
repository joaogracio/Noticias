using Noticias.ApiViewModels;
using Noticias.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Noticias.Api
{
    public class NoticiasController : ApiController
    {
        #region Base de Dados

        // Referência para a base de dados.
        private Models.NoticiasDbContext db = new Models.NoticiasDbContext();

        #endregion

        // GET: api/Noticias
        public IHttpActionResult Get()
        {
            var resultado = db.Noticia.
                Select(noticia => new
                {
                    noticia.NoticiasID,
                    noticia.Resumo,
                    noticia.Texto,
                    noticia.Titulo,
                    noticia.Data,
                    noticia.Imagens
                })
            .ToList();

            return Ok(resultado);
        }

        // GET: api/Noticias/5
        [ResponseType(typeof(Models.Noticias))]
        public IHttpActionResult Get(int id)
        {
            Models.Noticias noticia = db.Noticia.Find(id);

            if (noticia == null) {
                return NotFound();
            }

            var resultado = new
            {
                noticia.NoticiasID,
                noticia.Resumo,
                noticia.Texto,
                noticia.Titulo,
                noticia.Data,
                Imagens = noticia.Imagens.Select(img => new { img.ImagemID, img.Directorio, img.Descricao }).ToList()
                };
            
            return Ok(resultado);

        }

        // POST: api/Noticias
        [ResponseType(typeof(Models.Noticias))]
        public IHttpActionResult Post([FromBody] Models.Noticias model)
        {
            if (!ModelState.IsValid)
            {
                // O BadRequest permite usar o ModelState
                // para informar o cliente dos erros de validação
                // tal como no MVC.
                return BadRequest(ModelState);
            }

            // Para determinar o ID da proxima noticia
            var ID = db.Noticia.Select(id => id.NoticiasID).Max() + 1;

            var noticia = new Models.Noticias
            {
                NoticiasID = ID,
                Resumo = model.Resumo,
                Titulo = model.Titulo,
                Texto = model.Texto,
                Data = DateTime.Now,
                CategoriaFK = model.CategoriaFK,
                JornalistaFK = 1
            };

            db.Noticia.Add(noticia);

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

            return CreatedAtRoute("DefaultApi", new { id = noticia.NoticiasID }, noticia);
        }

        // PUT: api/Noticias/5
        public IHttpActionResult Put(int id, [FromBody] Models.Noticias model)
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

            // Caso Exista refencia para id fazer update
            var noticia = (from not in db.Noticia
                           where not.NoticiasID == id
                           select not).FirstOrDefault();

            noticia.CategoriaFK = model.CategoriaFK;
            noticia.Data = DateTime.Now;
            noticia.JornalistaFK = noticia.JornalistaFK;
            noticia.Resumo = model.Resumo;
            noticia.Texto = model.Texto;
            noticia.Titulo = model.Titulo;

            db.Entry(noticia);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                if (!(db.Noticia.Count(e => e.NoticiasID == id) > 0))
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
        
        // DELETE: api/Noticias/5
        public IHttpActionResult Delete(int id)
        {
            // Verificar se existe referencia para este id
            if ((db.Noticia.Select(not => not.NoticiasID == id) == null))
            {
                return BadRequest("Sorry, seems something wrong. Couldn't determine record to update.");
            }

            var noticia = (from not in db.Noticia
                           where not.NoticiasID == id
                           select not).FirstOrDefault();

            //var imagem = (from img in db.Imagem
            //              where img.NoticiaFK == id
            //              select img).FirstOrDefault();

            //db.Imagem.Remove(imagem);
            db.Noticia.Remove(noticia);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                if (!(db.Noticia.Count(e => e.NoticiasID == id) > 0))
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

        private Models.Noticias ModelToNoticia([FromBody] Models.Noticias model) {

            Models.Noticias noticia = new Models.Noticias(model);

            return noticia;
        }
    }

        
}

