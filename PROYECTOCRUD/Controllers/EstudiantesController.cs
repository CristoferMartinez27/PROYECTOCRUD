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
    public class EstudiantesController : Controller
    {
       
        private AppDBContext db = new AppDBContext();

        // GET: Estudiantes
        public ActionResult Index()
        {
            return View(db.estudiantes.ToList());
        }

        //Busqueda en Cola Estudiantes
        public ActionResult Busqueda(string buscar)
        {
            if(buscar is null)
            {
                return View(db.estudiantes.ToList());
            }
            return View(db.estudiantes.Where(estudiante => estudiante.CARNET==buscar || estudiante.NOMBRE.Contains(buscar)));
        }

        // GET: Estudiantes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CARNET,NOMBRE,FECHA_NACIMIENTO,FECHA_REGISTRO")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                estudiante.FECHA_REGISTRO = DateTime.Now;
                db.estudiantes.Add(estudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CARNET,NOMBRE,FECHA_NACIMIENTO,FECHA_REGISTRO")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }
        public ActionResult AgregarCola(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Estudiante estudiante = db.estudiantes.Find(id);
            db.estudiantes.Remove(estudiante);
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

        [HttpPost]
        
        public ActionResult AgregarCola([Bind(Include = "CARNET,NOMBRE,FECHA_NACIMIENTO,FECHA_REGISTRO")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                ColaEstudiante colaEstudiante = new ColaEstudiante();
                colaEstudiante.CARNET = estudiante.CARNET;
                colaEstudiante.NOMBRE = estudiante.NOMBRE;
                colaEstudiante.FECHA_NACIMIENTO = estudiante.FECHA_NACIMIENTO;
                colaEstudiante.FECHA_REGISTRO = estudiante.FECHA_REGISTRO;
                colaEstudiante.FECHA_ADICION = DateTime.Now;
                db.colaEstudiantes.Add(colaEstudiante);
                db.SaveChanges();

                return RedirectToAction("Busqueda");
            }

            return View(estudiante);
        }
    }
}
