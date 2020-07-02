using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Usmp.Fia.Dominio.Modelos;

namespace Usmp.Fia.WebApiBitacoras.Controllers
{
    public class ActividadesPorGrupoController : Controller
    {
        private ActividadesPorGrupoModel ActividadesPorGrupoModelmodel;
        public ActividadesPorGrupoController() 
        {
            ActividadesPorGrupoModelmodel = new ActividadesPorGrupoModel();
        }
        // GET: ActividadesPorGrupo
        public ActionResult Index()
        {
            return View(ActividadesPorGrupoModelmodel.getallActividadesPorGrupo());
        }

        // GET: ActividadesPorGrupo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActividadesPorGrupo/Create
        public ActionResult Create()
        {
            return View(ActividadesPorGrupoModelmodel);
        }

        // POST: ActividadesPorGrupo/Create
        [HttpPost]
        public ActionResult Create(ActividadesPorGrupoModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                model.states = Dominio.ObjetosValor.EntityStates.Add;
                model.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View(model);
            }
        }

        // GET: ActividadesPorGrupo/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ActividadesPorGrupoModelmodel.getActividadesPorGrupoID(id));

        }

        // POST: ActividadesPorGrupo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ActividadesPorGrupoModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                model.states = Dominio.ObjetosValor.EntityStates.Update;
                model.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View(model);
            }
        }

        // GET: ActividadesPorGrupo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActividadesPorGrupo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
