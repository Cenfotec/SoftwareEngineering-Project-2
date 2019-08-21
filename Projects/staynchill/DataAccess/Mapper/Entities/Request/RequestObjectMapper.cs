using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class RequestObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_HOTEL = "FK_HOTEL";
        private const string DB_COL_NOMBRE_HOTEL = "NOMBRE_HOTEL";
        private const string DB_COL_DATE = "FECHA";
        private const string DB_COL_DAILYSALES = "VENTAS_DIA";
        private const string DB_COL_MONTHLYSALES = "VENTAS_MES";
        private const string DB_COL_STATE = "ESTADO";
        private const string DB_COL_EMAIL = "CORREO";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var request = new Request
            {
                Id = GetIntValue(row, DB_COL_ID),
                Hotel = GetIntValue(row, DB_COL_HOTEL),
                HotelName = GetStringValue(row, DB_COL_NOMBRE_HOTEL),
                Date = GetDateValue(row, DB_COL_DATE),
                DailySales = GetDecimalValue(row, DB_COL_DAILYSALES),
                MonthlySales = GetDecimalValue(row, DB_COL_MONTHLYSALES),
                State = GetStringValue(row, DB_COL_STATE),
                Email = GetStringValue(row, DB_COL_EMAIL)
            };

            return request;
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var request = BuildObject(row);
                lstResults.Add(item: request);
            }

            return lstResults;
        }
    }
}