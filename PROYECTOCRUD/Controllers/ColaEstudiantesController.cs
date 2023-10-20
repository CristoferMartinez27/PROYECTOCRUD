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
    [Authorize]
    public class ColaEstudiantesController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: ColaEstudiantes
        public ActionResult Index()
        {
            return View(db.colaEstudiantes.OrderBy(cola => cola.FECHA_ADICION).ToList());
        }

        // GET: ColaEstudiantes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColaEstudiante colaEstudiante = db.colaEstudiantes.Find(id);
            if (colaEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(colaEstudiante);
        }

        // GET: ColaEstudiantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColaEstudiantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CARNET,NOMBRE,FECHA_NACIMIENTO,FECHA_REGISTRO,FECHA_ADICION")] ColaEstudiante colaEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.colaEstudiantes.Add(colaEstudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colaEstudiante);
        }

        // GET: ColaEstudiantes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColaEstudiante colaEstudiante = db.colaEstudiantes.Find(id);
            if (colaEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(colaEstudiante);
        }

        // POST: ColaEstudiantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CARNET,NOMBRE,FECHA_NACIMIENTO,FECHA_REGISTRO,FECHA_ADICION")] ColaEstudiante colaEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colaEstudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colaEstudiante);
        }

        // GET: ColaEstudiantes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColaEstudiante colaEstudiante = db.colaEstudiantes.Find(id);
            if (colaEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(colaEstudiante);
        }

        // POST: ColaEstudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ColaEstudiante colaEstudiante = db.colaEstudiantes.Find(id);
            db.colaEstudiantes.Remove(colaEstudiante);
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

        // GET: InscripcionEstudiante/Edit/5
        public ActionResult InscripcionEstudiante(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColaEstudiante colaEstudiante = db.colaEstudiantes.Find(id);
            if (colaEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(colaEstudiante);
        }

        [HttpPost]
        public ActionResult InscripcionEstudiante([Bind(Include = "CARNET,NOMBRE,FECHA_NACIMIENTO,FECHA_REGISTRO,FECHA_ADICION")] ColaEstudiante colaEstudiante)
        {
            if (ModelState.IsValid)
            {
                InscripcionEstudiante inscripcionEstudiante = new InscripcionEstudiante();
                inscripcionEstudiante.CARNET = colaEstudiante.CARNET;
                inscripcionEstudiante.NOMBRE = colaEstudiante.NOMBRE;
                inscripcionEstudiante.FECHA_NACIMIENTO = colaEstudiante.FECHA_NACIMIENTO;
                inscripcionEstudiante.FECHA_REGISTRO = colaEstudiante.FECHA_REGISTRO;
                inscripcionEstudiante.FECHA_ADICION = DateTime.Now;
                db.inscripcionEstudiantes.Add(inscripcionEstudiante);
                
                //Eliminar cola
                ColaEstudiante cola = db.colaEstudiantes.Find(colaEstudiante.CARNET);
                db.colaEstudiantes.Remove(cola);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(colaEstudiante);
        }
    }
}
