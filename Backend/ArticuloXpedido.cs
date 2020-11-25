using System;
using System.Collections.Generic;
using System.Text;

namespace Backend
{
    public class ArticuloXpedido
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public int cantidad { get; set; }
        public string importado { get; set; }
    }
}
