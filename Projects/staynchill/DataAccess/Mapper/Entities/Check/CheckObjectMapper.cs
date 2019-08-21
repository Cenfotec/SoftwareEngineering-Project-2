using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper {
    public class CheckObjectMapper : ObjectMapper {
        private const string DB_COL_FK_SUBRESERVACION = "ESTADO";

        public override BaseEntity BuildObject(Dictionary<string, object> row) {

            var check = new Check
            {
                FkSubReservacion = GetStringValue(row, DB_COL_FK_SUBRESERVACION)
            };

            return check;

        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var check = BuildObject(row);
                lstResults.Add(item: check);
            }

            return lstResults;
        }
    }
}
