using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Usmp.Fia.Dominio.Modelos;

namespace Usmp.Fia.WebApiBitacorasV2.Controllers
{
    public class SemestresController : Controller
    {
        //private UsmpFiaWebApiBitacorasContext db = new UsmpFiaWebApiBitacorasContext();
        private SemestresModel semestredatamodel;

        public SemestresController() 
        {
            semestredatamodel = new SemestresModel();

        }

        // GET: Semestres
        public ActionResult Index()
        {
            return View(semestredatamodel.getall());
        }

        // GET: Semestres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemestresModel semestresModel = semestredatamodel.getID(Convert.ToInt32(id));
            if (semestresModel == null)
            {
                return HttpNotFound();
            }
            return View(semestresModel);
        }

        // GET: Semestres/Create
        public ActionResult Create()
        {
            return View(semestredatamodel);
        }

        // POST: Semestres/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idsemestre,semestre,estado,fecha_crea,fecha_modif,user_crea,user_modif")] SemestresModel semestresModel)
        {
            if (ModelState.IsValid)
            {
                semestresModel.states = Dominio.ObjetosValor.EntityStates.Add;
                semestresModel.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semestresModel);
        }

        // GET: Semestres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemestresModel semestresModel = semestredatamodel.getID(Convert.ToInt32(id));
            if (semestresModel == null)
            {
                return HttpNotFound();
            }
            return View(semestresModel);
        }

        // POST: Semestres/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idsemestre,semestre,estado,fecha_crea,fecha_modif,user_crea,user_modif")] SemestresModel semestresModel)
        {
            if (ModelState.IsValid)
            {
                semestresModel.states = Dominio.ObjetosValor.EntityStates.Update;
                semestresModel.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semestresModel);
        }

        // GET: Semestres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemestresModel semestresModel = semestredatamodel.getID(Convert.ToInt32(id));
            if (semestresModel == null)
            {
                return HttpNotFound();
            }
            return View(semestresModel);
        }

        // POST: Semestres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SemestresModel semestresModel = semestredatamodel.getID(Convert.ToInt32(id));
            semestresModel.states = Dominio.ObjetosValor.EntityStates.Delete;
            semestresModel.SaveChanges();
            return RedirectToAction("Index");
        }

   

    }
}
