using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class ImageHotelObjectMapper : ObjectMapper
    {
        private const string DB_COL_VALUE = "VALOR";
        private const string DB_COL_TYPE = "TIPO";
        private const string DB_COL_HOTEL = "FK_HOTEL";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var imageHotel = new ImageHotel
            {
                Value = DB_COL_VALUE,
                Type = DB_COL_TYPE,
                Hotel = DB_COL_HOTEL
            };

            return imageHotel;
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var image = BuildObject(row);
                lstResults.Add(item: image);
            }

            return lstResults;
        }
    }
}
