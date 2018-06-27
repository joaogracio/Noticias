using Noticias.Models;
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
    public class JornalistasController : ApiController
    {
        #region Base de Dados

        // Referência para a base de dados.
        private Models.NoticiasDbContext db = new Models.NoticiasDbContext();

        #endregion

        // GET: api/Jornalistas
        public IHttpActionResult Get()
        {
            var jornalista = db.Jornalista.
                Select(jorn => new
                {
                    jorn.JornalistasID,
                    jorn.Nome
                })
                .ToList();

            return Ok(jornalista);
        }

        // GET: api/Jornalistas/5
        public IHttpActionResult Get(int id)
        {
            Models.Jornalistas jornalistas = db.Jornalista.Find(id);

            var resultado = db.Jornalista.
                Select(jornalista => new
                {
                    jornalista.JornalistasID,
                    jornalista.Nome
                }
                )
                .Where(jorn => jorn.JornalistasID == id)
                .ToList();

            return Ok(resultado);
        }

        // POST: api/Jornalistas
        [ResponseType(typeof(Models.Jornalistas))]
        public IHttpActionResult Post([FromBody] Jornalistas model)
        {
            if (!ModelState.IsValid)
            {
                // O BadRequest permite usar o ModelState
                // para informar o cliente dos erros de validação
                // tal como no MVC.
                return BadRequest(ModelState);
            }

            var ID = db.Jornalista.Select(id => id.JornalistasID).Max() + 1;

            var jornalista = new Models.Jornalistas {
                JornalistasID = ID,
                Nome = model.Nome
            };

            db.Jornalista.Add(jornalista);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException exp)
            {

                // Seria muito provável que o método
                // db.Agentes.Max(agente => agente.ID) + 1
                // fizesse com que este if resultasse no Conflict (HTTP 409).
                if (db.Jornalista.Count(e => e.JornalistasID == ID) > 0)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jornalista.JornalistasID }, jornalista);
        }

        // PUT: api/Jornalistas/5
        public IHttpActionResult Put(int id, [FromBody] Jornalistas model)
        {
            if (!ModelState.IsValid)
            {
                // O BadRequest permite usar o ModelState
                // para informar o cliente dos erros de validaçãow
                // tal como no MVC.
                return BadRequest(ModelState);
            }

            // Verificar se existe referencia para este id
            if (id > db.Jornalista.Select(not => not.JornalistasID).Max())
            {
                return BadRequest("Sorry, seems something wrong. Couldn't determine record to update.");
            }

            var jornalista = (from jor in db.Jornalista
                              where jor.JornalistasID == id
                              select jor).FirstOrDefault();

            jornalista.Nome = model.Nome;

            db.Entry(jornalista);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                if (!(db.Jornalista.Count(e => e.JornalistasID == id) > 0))
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

        // DELETE: api/Jornalistas/5
        public IHttpActionResult Delete(int id)
        {
            // Verificar se existe referencia para este id
            if ((db.Noticia.Select(not => not.NoticiasID == id) != null))
            {
                return BadRequest("Sorry, seems something wrong. Couldn't determine record to update.");
            }

            var jornalista = (from jor in db.Jornalista
                              where jor.JornalistasID == id
                              select jor).FirstOrDefault();

            db.Jornalista.Remove(jornalista);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                if (!(db.Jornalista.Count(e => e.JornalistasID == id) > 0))
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
