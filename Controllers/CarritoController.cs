using SuperMarket_Lois.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMarket_Lois.Controllers
{
    public class CarritoController : Controller
    {

        // Obtener el ID del carrito desde la sesión
        private string GetCarritoId()
        {
            if (Session["CarritoId"] == null)
            {
                Guid tempCartId = Guid.NewGuid();
                Session["CarritoId"] = tempCartId.ToString();
            }
            return Session["CarritoId"].ToString();
        }

        // Obtener los items del carrito desde la sesión
        private List<CarritoItem> GetCarritoItems()
        {
            if (Session["CarritoItems"] == null)
            {
                Session["CarritoItems"] = new List<CarritoItem>();
            }
            return (List<CarritoItem>)Session["CarritoItems"];
        }

        // Guardar los items del carrito en la sesión
        private void SaveCarritoItems(List<CarritoItem> items)
        {
            Session["CarritoItems"] = items;
        }

        // GET: Carrito
        public ActionResult Index()
        {
            ViewBag.Title = "Carrito de Compras - Lois's Market";
            return View(GetCarritoItems());
        }

        // POST: Carrito/Agregar
        [HttpPost]
        public ActionResult Agregar(int productoId, int cantidad = 1)
        {
            // Obtener todos los productos (en una aplicación real, esto vendría de una base de datos)
            var todosProductos = new List<Producto>();
            for (int i = 1; i <= 5; i++)
            {
                var productosController = new ProductosController();
                var metodo = productosController.GetType().GetMethod("GetProductosPorCategoria", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var productos = (List<Producto>)metodo.Invoke(productosController, new object[] { i });
                todosProductos.AddRange(productos);
            }

            // Buscar el producto
            var producto = todosProductos.FirstOrDefault(p => p.Id == productoId);
            if (producto == null)
            {
                return HttpNotFound();
            }

            // Obtener los items del carrito
            var carritoItems = GetCarritoItems();

            // Verificar si el producto ya está en el carrito
            var carritoItem = carritoItems.FirstOrDefault(c => c.ProductoId == productoId);
            if (carritoItem != null)
            {
                // Actualizar la cantidad
                carritoItem.Cantidad += cantidad;
            }
            else
            {
                // Agregar nuevo item al carrito
                carritoItem = new CarritoItem
                {
                    Id = carritoItems.Count > 0 ? carritoItems.Max(c => c.Id) + 1 : 1,
                    CarritoId = GetCarritoId(),
                    ProductoId = productoId,
                    Cantidad = cantidad,
                    Precio = producto.Precio,
                    Producto = producto
                };
                carritoItems.Add(carritoItem);
            }

            // Guardar los cambios
            SaveCarritoItems(carritoItems);

            // Redirigir al carrito
            return RedirectToAction("Index");
        }

        // POST: Carrito/Actualizar
        [HttpPost]
        public ActionResult Actualizar(int id, int cantidad)
        {
            // Obtener los items del carrito
            var carritoItems = GetCarritoItems();

            // Buscar el item
            var carritoItem = carritoItems.FirstOrDefault(c => c.Id == id);
            if (carritoItem == null)
            {
                return HttpNotFound();
            }

            // Actualizar la cantidad
            if (cantidad > 0)
            {
                carritoItem.Cantidad = cantidad;
            }
            else
            {
                // Eliminar el item si la cantidad es 0 o negativa
                carritoItems.Remove(carritoItem);
            }

            // Guardar los cambios
            SaveCarritoItems(carritoItems);

            // Redirigir al carrito
            return RedirectToAction("Index");
        }

        // POST: Carrito/Eliminar
        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            // Obtener los items del carrito
            var carritoItems = GetCarritoItems();

            // Buscar el item
            var carritoItem = carritoItems.FirstOrDefault(c => c.Id == id);
            if (carritoItem == null)
            {
                return HttpNotFound();
            }

            // Eliminar el item
            carritoItems.Remove(carritoItem);

            // Guardar los cambios
            SaveCarritoItems(carritoItems);

            // Redirigir al carrito
            return RedirectToAction("Index");
        }

        // POST: Carrito/Vaciar
        [HttpPost]
        public ActionResult Vaciar()
        {
            // Vaciar el carrito
            Session["CarritoItems"] = new List<CarritoItem>();

            // Redirigir al carrito
            return RedirectToAction("Index");
        }
    }
}