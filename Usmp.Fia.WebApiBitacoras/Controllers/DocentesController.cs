using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Usmp.Fia.Dominio.Modelos;

namespace Usmp.Fia.WebApiBitacoras.Controllers
{
    public class DocentesController : Controller
    {
        private DocentesModel docentesdatamodel;
        public DocentesController()
        {
            docentesdatamodel = new DocentesModel();
        }

        // GET: Docentes
        public ActionResult Index()
        {
            return View(docentesdatamodel.getall());
        }

        // GET: Docentes/Details/5
        public ActionResult Details(int id)
        {
            return View(docentesdatamodel.getID(id));
        }

        // GET: Docentes/Create
        public ActionResult Create()
        {
            return View(docentesdatamodel);
        }

        // POST: Docentes/Create
        [HttpPost]
        public ActionResult Create(DocentesModel model)
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

        // GET: Docentes/Edit/5
        public ActionResult Edit(int id)
        {
            return View(docentesdatamodel.getID(id));
        }

        // POST: Docentes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DocentesModel model)
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

        // GET: Docentes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Docentes/Delete/5
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
