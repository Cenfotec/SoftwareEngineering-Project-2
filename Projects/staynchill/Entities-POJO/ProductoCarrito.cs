using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class ProductoCarrito : BaseEntity
    {
        public int Id { get; set; }
        [DbColumn("CANT")]
        public int Cant { get; set; }
        [DbColumn("NOMBRE_PRODUCTO")]
        public string NombreProducto { get; set; }
        [DbColumn("PRECIO_BRUTO")]
        public decimal PrecioBruto { get; set; }
        [DbColumn("PRECIO_IMPUESTO")]
        public string PrecioImpuesto { get; set; }
        [DbColumn("FECHA")]
        public DateTime Fecha { get; set; }
        [DbColumn("FK_PRODUCTO")]
        public int FkProducto { get; set; }
        [PrimaryKey]
        [DbColumn("FK_CARRITO")]
        public int FkCarrito { get; set; }

        public ProductoCarrito()
        {

        }
    }
}
