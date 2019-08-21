using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper {
    public class RolObjectMapper : ObjectMapper {
        private const string DB_COL_NAME = "NOMBRE";
        private const string DB_COL_FK_HOTEL = "FK_HOTEL";
        private const string DB_COL_PERMISOS_STRING = "PERMISOS_STRING";

        public override BaseEntity BuildObject(Dictionary<string, object> row) {

            var rol = new Rol {
                Name = GetStringValue(row, DB_COL_NAME)
            };

            return rol;
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
