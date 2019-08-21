using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper {
    public class CommonObjectMapper : ObjectMapper {
        private const string DB_COL_ACTION = "ACCION";
        private const string DB_COL_TYPE = "TIPO";
        private const string DB_COL_DATE = "FECHA";

        public override BaseEntity BuildObject(Dictionary<string, object> row) {

            var common = new Common {
                Action = GetStringValue(row, DB_COL_ACTION),
                Type = GetStringValue(row, DB_COL_TYPE),
                Date = GetStringValue(row, DB_COL_DATE)
            };

            return common;

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
