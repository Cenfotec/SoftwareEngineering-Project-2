using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class HotelAnualAverageIncomeObjectMapper : ObjectMapper
    {
        private const string DB_COL_FK_HOTEL = "FK_HOTEL";
        private const string DB_COL_AVG_TOTAL = "AVG_TOTAL";

        public override BaseEntity BuildObject(Dictionary<string, object> row) => new HotelAnualAverageIncome
        {
            FkHotel = GetIntValue(row, DB_COL_FK_HOTEL),
            AvgTotal = GetIntValue(row, DB_COL_AVG_TOTAL)
        };

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
                lstResults.Add(item: BuildObject(row));

            return lstResults;
        }
    }
}
