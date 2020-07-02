using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Usmp.Fia.Dominio.Modelos;

namespace Usmp.Fia.WebApiBitacoras.Controllers
{
    public class EstudiantesApiController : ApiController
    {
        private EstudiantesModel estudiantesdatamodel;
        public EstudiantesApiController() 
        {
            estudiantesdatamodel = new EstudiantesModel();
        }

        // GET: api/EstudiantesApi
        public IEnumerable<EstudiantesModel> Get()
        {
            //return new string[] { "value1", "value2" };
            return estudiantesdatamodel.getall();
        }

        // GET: api/EstudiantesApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EstudiantesApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EstudiantesApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EstudiantesApi/5
        public void Delete(int id)
        {
        }
    }
}
