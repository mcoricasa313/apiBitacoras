using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Usmp.Fia.Dominio.Modelos;

namespace Usmp.Fia.WebApiBitacorasV2.Controllers
{
    public class GruposApiController : ApiController
    {
        private GrupoModel model;
        public GruposApiController() 
        {
            model = new GrupoModel();
        }

        // GET: api/GruposApi
        public IEnumerable<GrupoModel> Get()
        {
            return model.getall();
        }

        // GET: api/GruposApi/5
        public GrupoModel Get(int id)
        {
            return model.getID(id);
        }

        // POST: api/GruposApi
        public void Post([FromBody] GrupoModel model)
        {
            if (ModelState.IsValid)
            {
                model.states = Dominio.ObjetosValor.EntityStates.Add;
                model.SaveChanges();
            }


        }

        // PUT: api/GruposApi/5
        public void Put(int id, [FromBody] GrupoModel model)
        {
           

            if (ModelState.IsValid)
            {
                GrupoModel modelseleccionado = new GrupoModel();


                var grupoexiste = modelseleccionado.getall().Count(c => c.idgrupo == id) > 0;

                if (grupoexiste)
                {
                    model.states = Dominio.ObjetosValor.EntityStates.Update;
                    model.SaveChanges();
                }

                
            }

        }

        // DELETE: api/GruposApi/5
        public void Delete(int id)
        {
        }
    }
}
