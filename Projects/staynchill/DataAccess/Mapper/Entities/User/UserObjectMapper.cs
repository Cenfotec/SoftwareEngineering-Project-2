using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper {
    public class UserObjectMapper : ObjectMapper {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_CEDULA = "CEDULA";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_SEG_NOMBRE = "SEG_NOMBRE";
        private const string DB_COL_APELLIDO = "APELLIDO";
        private const string DB_COL_SEG_APELLIDO = "SEG_APELLIDO";
        private const string DB_COL_CORREO = "CORREO";
        private const string DB_COL_TELEFONO = "TELEFONO";
        private const string DB_COL_PROVINCIA = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRITO = "DISTRITO";
        private const string DB_COL_DIRECCION = "DIRECCION";
        private const string DB_COL_CONTRASENNA = "CONTRASENNA";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_ROL = "ROL";
        private const string DB_COL_IMAGENES = "FK_IMAGENES";
        private const string DB_COL_CODIGO = "CODIGO";

        public override BaseEntity BuildObject(Dictionary<string, object> row) {

            var user = new User {
                Id = GetIntValue(row, DB_COL_ID),
                Cedula = GetStringValue(row, DB_COL_CEDULA),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                SegNombre = GetStringValue(row, DB_COL_SEG_NOMBRE),
                Apellido = GetStringValue(row, DB_COL_APELLIDO),
                SegApellido = GetStringValue(row, DB_COL_SEG_APELLIDO),
                Correo = GetStringValue(row, DB_COL_CORREO),
                Telefono = GetStringValue(row, DB_COL_TELEFONO),
                Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                Canton = GetStringValue(row, DB_COL_CANTON),
                Distrito = GetStringValue(row, DB_COL_DISTRITO),
                Direccion = GetStringValue(row, DB_COL_DIRECCION),
                Contrasenna = GetStringValue(row, DB_COL_CONTRASENNA),
                Estado = GetStringValue(row, DB_COL_ESTADO),
                Rol = GetStringValue(row, DB_COL_ROL)
            };

            return user;

        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var rol = BuildObject(row);
                lstResults.Add(item: rol);
            }

            return lstResults;
        }
    }
}
