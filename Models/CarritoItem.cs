using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket_Lois.Models
{
    public class CarritoItem
    {
        public int Id { get; set; }
        public string CarritoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public virtual Producto Producto { get; set; }
    }
}