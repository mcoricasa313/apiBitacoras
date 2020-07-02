using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Usmp.Fia.Dominio.Modelos;

namespace Usmp.Fia.WebApiBitacorasV2.Controllers
{
    public class SemestresApiController : ApiController
    {
        private SemestresModel semsetredatamodel;

        public SemestresApiController() 
        {
            semsetredatamodel = new SemestresModel();
        }

        // GET: api/SemestresApi
        public IEnumerable<SemestresModel> Get()
        {
            //return new string[] { "value1", "value2" };
            return semsetredatamodel.getall();

        }

        // GET: api/SemestresApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SemestresApi
        [HttpPost]
        public IHttpActionResult Post([FromBody] SemestresModel model)
        {
            if (ModelState.IsValid)
            {
                model.states = Dominio.ObjetosValor.EntityStates.Add;
                model.SaveChanges();
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/SemestresApi/5
        public void Put(int id, [FromBody] SemestresModel model)
        {
            if (ModelState.IsValid)
            {
                SemestresModel modelseleccionado = new SemestresModel();


                var existe = modelseleccionado.getall().Count(c => c.idsemestre == id) > 0;

                if (existe)
                {
                    model.states = Dominio.ObjetosValor.EntityStates.Update;
                    model.SaveChanges();
                }


            }
        }

        // DELETE: api/SemestresApi/5
        public void Delete(int id)
        {
        }
    }
}
