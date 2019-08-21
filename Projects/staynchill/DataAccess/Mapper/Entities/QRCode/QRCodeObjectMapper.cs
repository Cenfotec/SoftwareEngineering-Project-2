using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class QRCodeObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_VALUE = "VALOR";
        private const string DB_COL_STATE = "ESTADO";
        private const string DB_COL_FK_SUB_RESERVACION = "FK_SUB_RESERVACION";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var code = new QRCode
            {
                Id = GetIntValue(row, DB_COL_ID),
                Value = GetStringValue(row, DB_COL_VALUE),
                State = GetStringValue(row, DB_COL_STATE),
                FK_SubReservation = GetIntValue(row, DB_COL_FK_SUB_RESERVACION)
            };
            return code;
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var code = BuildObject(row);
                lstResults.Add(item: code);
            }

            return lstResults;
        }
    }
}
