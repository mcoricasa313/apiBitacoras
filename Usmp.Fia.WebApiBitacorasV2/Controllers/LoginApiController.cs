using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Usmp.Fia.Dominio.Modelos;

namespace Usmp.Fia.WebApiBitacorasV2.Controllers
{
    public class LoginApiController : ApiController
    {
        private EstudiantesModel datamodel;
        public LoginApiController() 
        {
            datamodel = new EstudiantesModel();
        }

        [HttpPost]
        public Reply Post([FromBody] UsuarioLogin model) 
        {
            Reply or = new Reply();
            or.result = 0;
            try
            {
                var estudiante = datamodel.getPorUsuariClave(model.usuario, model.clave);
                if (estudiante!=null)
                {
                    or.result = 1;
                    or.data = Guid.NewGuid().ToString();
                }
                else
                {
                    or.message = "Datos incorrectos";
                }
            }
            catch (Exception e)
            {
                or.result = 0;
                or.message = "Ocurrio un error";
            }

            return or;
        }


        // GET: api/LoginEstudianteApi
        public IEnumerable<EstudiantesModel> Get()
        {
            return datamodel.getall();
        }

        // GET: api/LoginEstudianteApi/5
        public EstudiantesModel Get(int id)
        {
            return datamodel.getID(id);
        }

        // POST: api/LoginEstudianteApi
        //public void Post([FromBody]string value)
        //{
        //}

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
