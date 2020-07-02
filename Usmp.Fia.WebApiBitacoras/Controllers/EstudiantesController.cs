using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Usmp.Fia.Dominio.Modelos;

namespace Usmp.Fia.WebApiBitacoras.Controllers
{
    public class EstudiantesController : Controller
    {

        private EstudiantesModel estudiantesdatamodel;
        public EstudiantesController() 
        {
            estudiantesdatamodel = new EstudiantesModel();
        }

        // GET: Estudiantes
        public ActionResult Index()
        {
            return View(estudiantesdatamodel.getall());
        }

        // GET: Estudiantes/Details/5
        public ActionResult Details(int id)
        {
            return View(estudiantesdatamodel.getID(id));
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {
            return View(estudiantesdatamodel);
        }

        // POST: Estudiantes/Create
        [HttpPost]
        public ActionResult Create(EstudiantesModel model)
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

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(int id)
        {
            return View(estudiantesdatamodel.getID(id));
        }

        // POST: Estudiantes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EstudiantesModel model)
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

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estudiantes/Delete/5
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
