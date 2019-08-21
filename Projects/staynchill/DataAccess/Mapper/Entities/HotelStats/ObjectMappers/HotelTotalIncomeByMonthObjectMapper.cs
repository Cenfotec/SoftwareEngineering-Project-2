using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class HotelTotalIncomeByMonthObjectMapper : ObjectMapper
    {
        private const string DB_COL_FK_HOTEL = "FK_HOTEL";
        private const string DB_COL_SUM_GANANCIA_TOTAL = "SUM_GANANCIA_TOTAL";
        private const string DB_COL_MONTH_SALE = "MONTH_SALE";

        public override BaseEntity BuildObject(Dictionary<string, object> row) => new HotelTotalIncomeByMonth
        {
            FkHotel = GetIntValue(row, DB_COL_FK_HOTEL),
            SumTotalIncome = GetIntValue(row, DB_COL_SUM_GANANCIA_TOTAL),
            MonthSale = GetIntValue(row, DB_COL_MONTH_SALE)
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
