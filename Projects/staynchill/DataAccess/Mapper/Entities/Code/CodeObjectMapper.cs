using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper {
    public class CodeObjectMapper : ObjectMapper {
        private const string DB_COL_EMAIL = "CORREO";
        private const string DB_COL_CODE = "CODIGO";
        public override BaseEntity BuildObject(Dictionary<string, object> row) {

            var code = new Code {
                Correo = GetStringValue(row, DB_COL_EMAIL),
                Value = GetStringValue(row, DB_COL_CODE),
                };

            return code;

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
