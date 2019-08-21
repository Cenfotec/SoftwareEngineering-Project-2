using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class TaxObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_PERCENTAGE = "PERCENTAGE";
        private const string DB_COL_STATE = "STATE";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {
            return new Tax
            {
                Id = GetIntValue(row, DB_COL_ID),
                Name = GetStringValue(row, DB_COL_NAME),
                Percentage = GetDecimalValue(row, DB_COL_PERCENTAGE),
                State = GetStringValue(row, DB_COL_STATE)
            };
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var membership = BuildObject(row);
                lstResults.Add(item: membership);
            }

            return lstResults;
        }
    }
}
