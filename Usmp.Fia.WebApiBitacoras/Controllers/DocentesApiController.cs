using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Usmp.Fia.Dominio.Modelos;

namespace Usmp.Fia.WebApiBitacoras.Controllers
{
    public class DocentesApiController : ApiController
    {
        private DocentesModel datamodel;
        public DocentesApiController()
        {
            datamodel = new DocentesModel();
        }

        // GET: api/DocentesApi
        public IEnumerable<DocentesModel> Get()
        {
            //return new string[] { "value1", "value2" };
            return datamodel.getall();
        }

        // GET: api/DocentesApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DocentesApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DocentesApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DocentesApi/5
        public void Delete(int id)
        {
        }
    }
}
