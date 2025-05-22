using SuperMarket_Lois.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMarket_Lois.Controllers
{
    public class ContactoController : Controller
    {
        // GET: Contacto
        public ActionResult Index()
        {
            ViewBag.Title = "Contacto - Lois's Market";
            return View();
        }

        // POST: Contacto/Enviar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enviar(ContactoForms model)
        {
            if (ModelState.IsValid)
            {
                // En una aplicación real, aquí enviaríamos el correo electrónico
                // o guardaríamos el mensaje en la base de datos

                // Mostrar mensaje de éxito
                TempData["Mensaje"] = "¡Gracias por contactarnos! Te responderemos lo antes posible.";

                // Redirigir a la página de contacto
                return RedirectToAction("Index");
            }

            // Si el modelo no es válido, volver a mostrar el formulario con errores
            return View("Index", model);
        }
    }
}