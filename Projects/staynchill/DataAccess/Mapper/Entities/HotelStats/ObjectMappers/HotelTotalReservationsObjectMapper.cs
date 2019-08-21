using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class HotelTotalReservationsObjectMapper : ObjectMapper
    {
        private const string DB_COL_FK_HOTEL = "FK_HOTEL";
        private const string DB_COL_TOTAL_RESERVACIONES = "TOTAL_RESERVACIONES";

        public override BaseEntity BuildObject(Dictionary<string, object> row) => new HotelTotalReservations
        {
            FkHotel = GetIntValue(row, DB_COL_FK_HOTEL),
            TotalReservations = GetIntValue(row, DB_COL_TOTAL_RESERVACIONES)
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