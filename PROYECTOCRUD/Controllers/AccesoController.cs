using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; //para no permitir los ingresos por otro lado que no sea login
using PROYECTOCRUD.Data;
using PROYECTOCRUD.Models;

namespace PROYECTOCRUD.Controllers
{
    public class AccesoController : Controller
    {
        private AppDBContext db = new AppDBContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string USER, string PASSWORD)
        {
            var usuario = db.usuarios.FirstOrDefault(u => u.USER == USER && u.PASSWORD == PASSWORD);
            if (usuario != null)
            {
                FormsAuthentication.SetAuthCookie(usuario.USER, false);
                // Usuario autenticado
                return RedirectToAction("Index", "Estudiantes");
            }
            else
            {
                // Usuario no válido
                ViewBag.ErrorMessage = "Usuario y/o Contraseña invalidas";
                return View();
            }
        }
    }
}