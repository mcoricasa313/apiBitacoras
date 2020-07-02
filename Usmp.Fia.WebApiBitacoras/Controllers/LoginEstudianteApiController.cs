using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Usmp.Fia.Dominio.Modelos;

namespace Usmp.Fia.WebApiBitacoras.Controllers
{
    public class LoginEstudianteApiController : ApiController
    {
        private EstudiantesModel model;
        public LoginEstudianteApiController() 
        {
            model = new EstudiantesModel();
        }
        // GET: api/LoginEstudianteApi
        public IEnumerable<EstudiantesModel> Get()
        {
            return model.getall();
        }

        // GET: api/LoginEstudianteApi/5
        public EstudiantesModel Get(int id)
        {
            return model.getID(id);
        }

        // POST: api/LoginEstudianteApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LoginEstudianteApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LoginEstudianteApi/5
        public void Delete(int id)
        {
        }
    }
}
