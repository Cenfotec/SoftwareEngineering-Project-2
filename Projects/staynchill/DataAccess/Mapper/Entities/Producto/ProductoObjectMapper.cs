using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class ProductoObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_SERVICE = "FK_SERVICE";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_DESCRIPCION = "DESCRIPCION";
        private const string DB_COL_PRECIO = "PRECIO";
        private const string DB_COL_STATE = "ESTADO";
        private const string DB_COL_CANT = "CANT";
        private const string DB_COL_VALUE = "VALOR";
        private const string DB_COL_TYPE = "TIPO";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var producto = new Producto
            {
                Id = GetIntValue(row, DB_COL_ID),
                Service = GetIntValue(row, DB_COL_SERVICE),
                Name = GetStringValue(row, DB_COL_NOMBRE),
                Description = GetStringValue(row, DB_COL_DESCRIPCION),
                Price = GetDecimalValue(row, DB_COL_PRECIO),
                State = GetStringValue(row, DB_COL_STATE),
                Cant = GetIntValue(row, DB_COL_CANT),
                Value = GetStringValue(row, DB_COL_VALUE),
                Type = GetStringValue(row, DB_COL_TYPE)
            };
            return producto;
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var product = BuildObject(row);
                lstResults.Add(item: product);
            }

            return lstResults;
        }
    }
}
