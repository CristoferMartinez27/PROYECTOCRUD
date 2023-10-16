using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PROYECTOCRUD.Controllers
{
    public class ESTUDIANTESController : Controller
    {
        //private Estudia db = new Estudia();

        // GET: ESTUDIANTES
        public ActionResult Index()
        {
            //return View(db.ESTUDIANTES.ToList());
            return View();
        }

        // GET: ESTUDIANTES/Details/5
        public ActionResult Details(decimal id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ESTUDIANTES eSTUDIANTES = db.ESTUDIANTES.Find(id);
            //if (eSTUDIANTES == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(eSTUDIANTES);
            return View();
        }

        // GET: ESTUDIANTES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ESTUDIANTES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CARNET,NOMBRE,FECHA_NACIMIENTO,FECHA_REGISTRO")] ESTUDIANTES eSTUDIANTES)
        public ActionResult Crete()
        {
            //if (ModelState.IsValid)
            //{
            //    db.ESTUDIANTES.Add(eSTUDIANTES);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(eSTUDIANTES);
            return View();
        }

        // GET: ESTUDIANTES/Edit/5
        public ActionResult Edit(decimal id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ESTUDIANTES eSTUDIANTES = db.ESTUDIANTES.Find(id);
            //if (eSTUDIANTES == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(eSTUDIANTES);
            return View();
        }

        // POST: ESTUDIANTES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CARNET,NOMBRE,FECHA_NACIMIENTO,FECHA_REGISTRO")] ESTUDIANTES eSTUDIANTES)
        public ActionResult Edit()
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(eSTUDIANTES).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(eSTUDIANTES);
            return View();
        }

        // GET: ESTUDIANTES/Delete/5
        public ActionResult Delete(decimal id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ESTUDIANTES eSTUDIANTES = db.ESTUDIANTES.Find(id);
            //if (eSTUDIANTES == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(eSTUDIANTES);
            return View();
        }

        // POST: ESTUDIANTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            //ESTUDIANTES eSTUDIANTES = db.ESTUDIANTES.Find(id);
            //db.ESTUDIANTES.Remove(eSTUDIANTES);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
