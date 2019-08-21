using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class HotelAnualTotalIncomeObjectMapper : ObjectMapper
    {
        private const string DB_COL_FK_HOTEL = "FK_HOTEL";
        private const string DB_COL_SUM_PRECIO_BASE = "SUM_PRECIO_BASE";

        public override BaseEntity BuildObject(Dictionary<string, object> row) => new HotelAnualTotalIncome
        {
            FkHotel = GetIntValue(row, DB_COL_FK_HOTEL),
            SumBasePrice = GetIntValue(row, DB_COL_SUM_PRECIO_BASE)
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
