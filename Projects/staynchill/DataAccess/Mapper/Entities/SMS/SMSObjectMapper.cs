using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class SMSObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_FK_HOTEL = "FK_HOTEL";
        private const string DB_COL_MENSAJE = "MENSAJE";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {

            var sms = new SMS
            {
                Id = GetIntValue(row, DB_COL_ID),
                FkHotel = GetIntValue(row, DB_COL_FK_HOTEL),
                Message = GetStringValue(row, DB_COL_MENSAJE)
            };

            return sms;

        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var sms = BuildObject(row);
                lstResults.Add(item: sms);
            }

            return lstResults;
        }
    }
}
