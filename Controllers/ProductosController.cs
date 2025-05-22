using SuperMarket_Lois.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static SuperMarket_Lois.Models.Categoria;

namespace SuperMarket_Lois.Controllers
{
    public class ProductosController : Controller
    {
        // Lista de categorías
        private List<Categoria> GetCategorias()
        {
            return new List<Categoria>
            {
                new Categoria { Id = 1, Nombre = "Frutas y Verduras", Descripcion = "Productos frescos del campo" },
                new Categoria { Id = 2, Nombre = "Lácteos", Descripcion = "Leche, quesos y yogures" },
                new Categoria { Id = 3, Nombre = "Panadería", Descripcion = "Pan y productos horneados" },
                new Categoria { Id = 4, Nombre = "Carnicería", Descripcion = "Carnes frescas y embutidos" },
                new Categoria { Id = 5, Nombre = "Bebidas", Descripcion = "Refrescos, jugos y agua" }
            };
        }

        // Lista de productos por categoría
        private List<Producto> GetProductosPorCategoria(int categoriaId)
        {
            var todosProductos = new List<Producto>
            {
                // Frutas y Verduras (Categoría 1)
                new Producto { Id = 1, Nombre = "Manzanas Rojas", Descripcion = "Manzanas frescas y jugosas", Precio = 50m, ImagenUrl = "/Content/images/productos/Manzana.jpg", Disponible = true, CategoriaId = 1 },
                new Producto { Id = 2, Nombre = "Plátanos", Descripcion = "Plátanos maduros y dulces", Precio = 12m, ImagenUrl = "/Content/images/productos/banano.jpg", Disponible = true, CategoriaId = 1 },
                new Producto { Id = 3, Nombre = "Tomates", Descripcion = "Tomates frescos para ensalada", Precio = 40m, ImagenUrl = "/Content/images/productos/tomate.jpg", Disponible = true, CategoriaId = 1 },
                
                // Lácteos (Categoría 2)
                new Producto { Id = 4, Nombre = "Leche Entera", Descripcion = "Leche fresca de alta calidad", Precio = 62m, ImagenUrl = "/Content/images/productos/Leche.jpg", Disponible = true, CategoriaId = 2 },
                new Producto { Id = 5, Nombre = "Queso Manchego", Descripcion = "Queso curado de oveja", Precio = 80m, ImagenUrl = "/Content/images/productos/queso.jpg", Disponible = true, CategoriaId = 2 },
                new Producto { Id = 6, Nombre = "Yogur Natural", Descripcion = "Yogur cremoso sin azúcar", Precio = 70m, ImagenUrl = "/Content/images/productos/yogur.jpg", Disponible = true, CategoriaId = 2 },
                
                // Panadería (Categoría 3)
                new Producto { Id = 7, Nombre = "Pan Integral", Descripcion = "Pan recién horneado con granos integrales", Precio = 110m, ImagenUrl = "/Content/images/productos/Pan.jpg", Disponible = true, CategoriaId = 3 },
                new Producto { Id = 8, Nombre = "Croissants", Descripcion = "Croissants de mantequilla", Precio = 35m, ImagenUrl = "/Content/images/productos/croissants.jpg", Disponible = true, CategoriaId = 3 },
                
                // Carnicería (Categoría 4)
                new Producto { Id = 9, Nombre = "Pollo Entero", Descripcion = "Pollo fresco de granja", Precio = 90m, ImagenUrl = "/Content/images/productos/Pollo.jpg", Disponible = true, CategoriaId = 4 },
                new Producto { Id = 10, Nombre = "Carne Molida", Descripcion = "Carne de res molida fresca", Precio = 70m, ImagenUrl = "/Content/images/productos/carne.jpg", Disponible = true, CategoriaId = 4 },
                
                // Bebidas (Categoría 5)
                new Producto { Id = 11, Nombre = "Agua Mineral", Descripcion = "Agua mineral natural", Precio = 35m, ImagenUrl = "/Content/images/productos/agua.jpg", Disponible = true, CategoriaId = 5 },
                new Producto { Id = 12, Nombre = "Refresco de Cola", Descripcion = "Refresco de cola en lata", Precio = 20m, ImagenUrl = "/Content/images/productos/refresco.jpg", Disponible = true, CategoriaId = 5 }
            };

            return todosProductos.Where(p => p.CategoriaId == categoriaId).ToList();
        }

        // GET: Productos
        public ActionResult Index()
        {
            ViewBag.Title = "Productos - Lois's Market";
            return View(GetCategorias());
        }

        // GET: Productos/Categoria/5
        public ActionResult Categoria(int id)
        {
            var categoria = GetCategorias().FirstOrDefault(c => c.Id == id);
            if (categoria == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categoria = categoria;
            ViewBag.Title = categoria.Nombre + " - Lois's Market";

            return View(GetProductosPorCategoria(id));
        }

        // GET: Productos/Detalle/5
        public ActionResult Detalle(int id)
        {
            var todosProductos = new List<Producto>();
            foreach (var categoria in GetCategorias())
            {
                todosProductos.AddRange(GetProductosPorCategoria(categoria.Id));
            }

            var producto = todosProductos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = producto.Nombre + " - Lois's Market";
            return View(producto);
        }
    }
}