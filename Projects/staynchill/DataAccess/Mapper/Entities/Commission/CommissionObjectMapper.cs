using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper {
    public class CommissionObjectMapper : ObjectMapper {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_FK_HOTEL = "FK_HOTEL";
        private const string DB_COL_PERCENTAGE = "PORCENTAJE";
        
        public override BaseEntity BuildObject(Dictionary<string, object> row) {

            var commission = new Commission {
                Id = GetIntValue(row, DB_COL_ID),
                FkHotel = GetIntValue(row, DB_COL_FK_HOTEL),
                Percentage = GetStringValue(row, DB_COL_PERCENTAGE)
            };

            return commission;

        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var commission = BuildObject(row);
                lstResults.Add(item: commission);
            }

            return lstResults;
        }
    }
}
