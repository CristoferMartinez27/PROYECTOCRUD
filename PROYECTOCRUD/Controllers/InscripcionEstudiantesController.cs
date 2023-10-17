using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROYECTOCRUD.Data;
using PROYECTOCRUD.Models;

namespace PROYECTOCRUD.Controllers
{
    public class InscripcionEstudiantesController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: InscripcionEstudiantes
        public ActionResult Index()
        {
            return View(db.inscripcionEstudiantes.ToList());
        }

        // GET: InscripcionEstudiantes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscripcionEstudiante inscripcionEstudiante = db.inscripcionEstudiantes.Find(id);
            if (inscripcionEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(inscripcionEstudiante);
        }

        // GET: InscripcionEstudiantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InscripcionEstudiantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CARNET,NOMBRE,FECHA_NACIMIENTO,FECHA_REGISTRO,FECHA_ADICION")] InscripcionEstudiante inscripcionEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.inscripcionEstudiantes.Add(inscripcionEstudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inscripcionEstudiante);
        }

        // GET: InscripcionEstudiantes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscripcionEstudiante inscripcionEstudiante = db.inscripcionEstudiantes.Find(id);
            if (inscripcionEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(inscripcionEstudiante);
        }

        // POST: InscripcionEstudiantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CARNET,NOMBRE,FECHA_NACIMIENTO,FECHA_REGISTRO,FECHA_ADICION")] InscripcionEstudiante inscripcionEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscripcionEstudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inscripcionEstudiante);
        }

        // GET: InscripcionEstudiantes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscripcionEstudiante inscripcionEstudiante = db.inscripcionEstudiantes.Find(id);
            if (inscripcionEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(inscripcionEstudiante);
        }

        // POST: InscripcionEstudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            InscripcionEstudiante inscripcionEstudiante = db.inscripcionEstudiantes.Find(id);
            db.inscripcionEstudiantes.Remove(inscripcionEstudiante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
