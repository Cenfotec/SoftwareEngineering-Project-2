using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class ArrayProductos
    {
        public List<ProductoCarrito> productsArray { get; set; }
    }

    public class ArrayProductosWithCorreo
    {
        public List<ProductoCarrito> productsArray { get; set; }
        public string correo { get; set; }
        public int hotel { get; set; }
    }
}
