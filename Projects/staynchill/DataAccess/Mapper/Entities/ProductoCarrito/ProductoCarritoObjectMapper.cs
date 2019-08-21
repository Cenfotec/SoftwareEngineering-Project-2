using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ProductoCarritoObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_CANT = "CANT";
        private const string DB_COL_NOMBRE_PRODUCTO = "NOMBRE_PRODUCTO";
        private const string DB_COL_PRECIO_BRUTO = "PRECIO_BRUTO";
        private const string DB_COL_PRECIO_IMPUESTO = "PRECIO_IMPUESTO";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_FK_PRODUCTO = "FK_PRODUCTO";
        private const string DB_COL_FK_CARRITO = "FK_CARRITO";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var productoCarrito = new ProductoCarrito
            {
                Id = GetIntValue(row, DB_COL_ID),
                Cant = GetIntValue(row, DB_COL_CANT),
                NombreProducto = GetStringValue(row, DB_COL_NOMBRE_PRODUCTO),
                PrecioBruto = GetDecimalValue(row, DB_COL_PRECIO_BRUTO),
                PrecioImpuesto = GetStringValue(row, DB_COL_PRECIO_IMPUESTO),
                Fecha = GetDateValue(row, DB_COL_FECHA),
                FkProducto = GetIntValue(row, DB_COL_FK_PRODUCTO),
                FkCarrito = GetIntValue(row, DB_COL_FK_CARRITO)
            };
            return productoCarrito;
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var productoCarrito = BuildObject(row);
                lstResults.Add(item: productoCarrito);
            }

            return lstResults;
        }
    }
}
