using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper {
    public class ProductObjectMapper : ObjectMapper {
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_DESCRIPTION = "DESCRIPTION";
        private const string DB_COL_CODE = "CODE";
        private const string DB_COL_ARRIVAL_DATE = "ARRIVAL_DATE";
        private const string DB_COL_STATE = "STATE";

        public override BaseEntity BuildObject(Dictionary<string, object> row) {

            var product = new Product {
                Code = GetStringValue(row, DB_COL_CODE),
                Name = GetStringValue(row, DB_COL_NAME),
                Description = GetStringValue(row, DB_COL_DESCRIPTION),
                ArrivalDate = GetDateValue(row, DB_COL_ARRIVAL_DATE),
                State = GetStringValue(row, DB_COL_STATE)
            };

            return product;

        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var product = BuildObject(row);
                lstResults.Add(item: product);
            }

            return lstResults;
        }
    }
}
