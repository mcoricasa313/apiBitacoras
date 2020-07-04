using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using Usmp.Fia.Dominio.Modelos;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

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
        public SemestresModel Post([FromBody] SemestresModel model)
        {
            model = new SemestresModel();
            //if (ModelState.IsValid)
            //{
            //    model.states = Dominio.ObjetosValor.EntityStates.Add;
            //    model.SaveChanges();
            //    return Ok(model).ToString();
            //}
            //else
            //{
            //    return BadRequest().ToString();
            //}
            //return Ok("funciona "+model);


            //return Json<SemestresModel>(model);
            return model;
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
