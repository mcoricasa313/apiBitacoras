using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Usmp.Fia.Dominio.Modelos;
using Usmp.Fia.WebApiBitacorasV2.Data;

namespace Usmp.Fia.WebApiBitacorasV2.Controllers
{
    public class SemestresModelsController : ApiController
    {
        private UsmpFiaWebApiBitacorasV2Context db = new UsmpFiaWebApiBitacorasV2Context();

        // GET: api/SemestresModels
        public IQueryable<SemestresModel> GetSemestresModels()
        {
            return db.SemestresModels;
        }

        // GET: api/SemestresModels/5
        [ResponseType(typeof(SemestresModel))]
        public IHttpActionResult GetSemestresModel(int id)
        {
            SemestresModel semestresModel = db.SemestresModels.Find(id);
            if (semestresModel == null)
            {
                return NotFound();
            }

            return Ok(semestresModel);
        }

        // PUT: api/SemestresModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSemestresModel(int id, SemestresModel semestresModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != semestresModel.idsemestre)
            {
                return BadRequest();
            }

            db.Entry(semestresModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SemestresModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SemestresModels
        [ResponseType(typeof(SemestresModel))]
        public IHttpActionResult PostSemestresModel(SemestresModel semestresModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            semestresModel.states = Dominio.ObjetosValor.EntityStates.Add;
            semestresModel.SaveChanges();
            //db.SemestresModels.Add(semestresModel);
            //db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = semestresModel.idsemestre }, semestresModel);
        }

        // DELETE: api/SemestresModels/5
        [ResponseType(typeof(SemestresModel))]
        public IHttpActionResult DeleteSemestresModel(int id)
        {
            SemestresModel semestresModel = db.SemestresModels.Find(id);
            if (semestresModel == null)
            {
                return NotFound();
            }

            db.SemestresModels.Remove(semestresModel);
            db.SaveChanges();

            return Ok(semestresModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SemestresModelExists(int id)
        {
            return db.SemestresModels.Count(e => e.idsemestre == id) > 0;
        }
    }
}