using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class HotelTotalReservationsByMonthObjectMapper : ObjectMapper
    {
        private const string DB_COL_FK_HOTEL = "FK_HOTEL";
        private const string DB_COL_CANT_VENTAS = "CANT_VENTAS";
        private const string DB_COL_MONTH_SALE = "MONTH_SALE";

        public override BaseEntity BuildObject(Dictionary<string, object> row) => new HotelTotalReservationsByMonth
        {
            FkHotel = GetIntValue(row, DB_COL_FK_HOTEL),
            CantSales = GetIntValue(row, DB_COL_CANT_VENTAS),
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
