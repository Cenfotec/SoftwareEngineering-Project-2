using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class UbicationObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_HOTEL = "FK_HOTEL";
        private const string DB_COL_LATITUDE = "LATITUD";
        private const string DB_COL_LONGITUDE = "LONGITUD";
        private const string DB_COL_PROVINCE = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRICT = "DISTRITO";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {

            var ubication = new Ubication
            {
                Id = GetIntValue(row, DB_COL_ID),
                Hotel = GetIntValue(row, DB_COL_HOTEL),
                Latitude = GetStringValue(row, DB_COL_LATITUDE),
                Longitude = GetStringValue(row, DB_COL_LONGITUDE),
                Province = GetIntValue(row, DB_COL_PROVINCE),
                Canton = GetIntValue(row, DB_COL_CANTON),
                District = GetIntValue(row, DB_COL_DISTRICT)
            };

            return ubication;
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var ubication = BuildObject(row);
                lstResults.Add(item: ubication);
            }

            return lstResults;
        }
    }
}
