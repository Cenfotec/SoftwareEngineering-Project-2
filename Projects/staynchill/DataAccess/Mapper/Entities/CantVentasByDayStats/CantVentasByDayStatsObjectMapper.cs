using Entities_POJO;
using System.Collections.Generic;



namespace DataAccess.Mapper
{
    public class CantVentasByDayStatsObjectMapper : ObjectMapper
    {
        private const string DB_COL_DAY_OF_MONTH = "DAY_OF_MONTH";
        private const string DB_COL_CANT_VENTAS = "CANT_VENTAS";

        public override BaseEntity BuildObject(Dictionary<string, object> row) => new CantVentasByDayStats
        {
            DayOfMonth = GetIntValue(row, DB_COL_DAY_OF_MONTH),
            CantVentas = GetIntValue(row, DB_COL_CANT_VENTAS)
        };

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var cantVentasByDayStats = BuildObject(row);
                lstResults.Add(item: cantVentasByDayStats);
            }

            return lstResults;
        }
    }
}