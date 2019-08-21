using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper {
    public class MembershipObjectMapper : ObjectMapper {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_FK_HOTEL = "FK_HOTEL";
        private const string DB_COL_PRECIO = "PRECIO";
        private const string DB_COL_CANT_MESES = "CANT_MESES";
        private const string DB_COL_FECHA_CREACION = "FECHA_CREACION";
        private const string DB_COL_FECHA_FIN = "FECHA_FIN";
        private const string DB_COL_ESTADO = "ESTADO";

        public override BaseEntity BuildObject(Dictionary<string, object> row) {

            var membership = new Membership {
                Id = GetIntValue(row, DB_COL_ID),
                FkHotel = GetIntValue(row, DB_COL_FK_HOTEL),
                Price = GetDecimalValue(row, DB_COL_PRECIO),
                NumberMonths = GetIntValue(row, DB_COL_CANT_MESES),
                StartDate = GetDateValue(row, DB_COL_FECHA_CREACION),
                EndDate = GetDateValue(row, DB_COL_FECHA_FIN),
                State = GetStringValue(row, DB_COL_ESTADO)
            };

            return membership;

        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var membership = BuildObject(row);
                lstResults.Add(item: membership);
            }

            return lstResults;
        }
    }
}
