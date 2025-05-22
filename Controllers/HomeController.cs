using SuperMarket_Lois.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMarket_Lois.Controllers
{
    public class HomeController : Controller
    {
        // Lista de productos destacados para mostrar en la página de inicio
        private List<Producto> GetProductosDestacados()
        {
            return new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Manzanas Rojas", Descripcion = "Manzanas frescas y jugosas", Precio = 40m, ImagenUrl = "/Content/images/productos/Manzana.jpg", Disponible = true, CategoriaId = 1 },
                new Producto { Id = 2, Nombre = "Leche Entera", Descripcion = "Leche fresca de alta calidad", Precio = 90m, ImagenUrl = "/Content/images/productos/Leche.jpg", Disponible = true, CategoriaId = 2 },
                new Producto { Id = 3, Nombre = "Pan Integral", Descripcion = "Pan recién horneado con granos integrales", Precio = 40m, ImagenUrl = "/Content/images/productos/Pan.jpg", Disponible = true, CategoriaId = 3 },
                new Producto { Id = 4, Nombre = "Pollo Entero", Descripcion = "Pollo fresco de granja", Precio = 150m, ImagenUrl = "/Content/images/productos/Pollo.jpg", Disponible = true, CategoriaId = 4 }
            };
        }

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Inicio - Lois's Market";
            return View(GetProductosDestacados());
        }

        // Método para cambiar el idioma
        public ActionResult CambiarIdioma(string language, string returnUrl)
        {
            // Guardar el idioma seleccionado en una cookie
            HttpCookie cookie = new HttpCookie("language");
            cookie.Value = language;
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);

            // Redirigir a la página anterior
            if (!string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction("Index", "Home");
        }
    }
}