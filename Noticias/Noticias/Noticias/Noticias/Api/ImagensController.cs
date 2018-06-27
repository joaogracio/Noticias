using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Noticias.Api
{
    public class ImagensController : ApiController
    {

        #region Base de Dados

        // Referência para a base de dados.
        private Models.NoticiasDbContext db = new Models.NoticiasDbContext();

        #endregion

        // GET: api/Imagens
        public IHttpActionResult Get()
        {
            var imagem = db.Imagem.
                Select(img=> new
                {
                    img.ImagemID,
                    img.NoticiaFK,
                    img.Tipo,
                    img.Descricao,
                    img.Directorio
                })
                .ToList();

            return Ok(imagem);
        }

        // GET: api/Imagens/5
        [ResponseType(typeof(Models.Imagens))]
        public IHttpActionResult Get(int id)
        {
            Models.Imagens imagens = db.Imagem.Find(id);
            if (imagens == null) {
                return NotFound();
            }

            var imagem = db.Imagem
                .Select(img => new
                {
                    img.ImagemID,
                    img.NoticiaFK,
                    img.Descricao,
                    img.Directorio,
                    img.Tipo
                })
                .Where(img => img.ImagemID == id)
                .ToList();

            return Ok(imagem);
        }

        // POST: api/Imagens
        [ResponseType(typeof(Models.Imagens))]
        public IHttpActionResult Post([FromBody] Models.Imagens model)
        {
            if (!ModelState.IsValid)
            {
                // O BadRequest permite usar o ModelState
                // para informar o cliente dos erros de validação
                // tal como no MVC.
                return BadRequest(ModelState);
            }

            var ID = db.Imagem.Select(id => id.ImagemID).Max() + 1;

            var imagem = new Models.Imagens
            {
                ImagemID = ID,
                NoticiaFK = model.NoticiaFK,
                Tipo = model.Tipo,
                Descricao = model.Descricao,
                Directorio = model.Directorio
            };

            db.Imagem.Add(imagem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException exp)
            {

                // Seria muito provável que o método
                // db.Agentes.Max(agente => agente.ID) + 1
                // fizesse com que este if resultasse no Conflict (HTTP 409).
                if (db.Imagem.Count(e => e.ImagemID == ID) > 0)
                {
                    return Conflict();
                }
                else
                {
                    throw exp;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = imagem.ImagemID }, imagem);
        }

        // PUT: api/Imagens/5
        public IHttpActionResult Put(int id, [FromBody] Models.Imagens model)
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

            var imagem = (from img in db.Imagem
                          where img.ImagemID == id
                          select img).FirstOrDefault();

            imagem.Descricao = model.Descricao;
            imagem.Directorio = model.Directorio;
            imagem.NoticiaFK = model.NoticiaFK;
            imagem.Tipo = model.Tipo;

            db.Entry(imagem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                if (!(db.Imagem.Count(e => e.ImagemID == id) > 0))
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

        // DELETE: api/Imagens/5
        public IHttpActionResult Delete(int id)
        {
            // Verificar se existe referencia para este id
            if ((db.Imagem.Select(not => not.ImagemID == id) != null))
            {
                return BadRequest("Sorry, seems something wrong. Couldn't determine record to update.");
            }

            var imagem = (from img in db.Imagem
                          where img.ImagemID == id
                          select img).FirstOrDefault();

            db.Imagem.Remove(imagem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                if (!(db.Imagem.Count(e => e.ImagemID == id) > 0))
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
