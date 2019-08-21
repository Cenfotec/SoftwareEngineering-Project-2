using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper {
    public class VistaReservacionObjectMapper : ObjectMapper {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_USER = "USUARIO";
        private const string DB_COL_HOTEL = "HOTEL";
        private const string DB_COL_ROOM_NUMBER = "NUM_HABITACION";
        private const string DB_COL_BEGIN_DATE = "FECHA_INCIO";
        private const string DB_COL_END_DATE = "FECHA_FIN";
        private const string DB_COL_PRICE = "PRECIO";
        private const string DB_COL_STATUS = "ESTADO";

        public override BaseEntity BuildObject(Dictionary<string, object> row) {

            var rol = new VistaReservacion
            {
                Id = GetIntValue(row, DB_COL_ID),
                User = GetStringValue(row, DB_COL_USER),
                Hotel = GetStringValue(row, DB_COL_HOTEL),
                RoomNum = GetIntValue(row, DB_COL_ROOM_NUMBER),
                BeginDate = GetDateValue(row, DB_COL_BEGIN_DATE),
                EndDate = GetDateValue(row, DB_COL_END_DATE),
                Price = GetDecimalValue(row, DB_COL_PRICE),
                Status = GetStringValue(row, DB_COL_STATUS)
            };

            return rol;
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var rol = BuildObject(row);
                lstResults.Add(item: rol);
            }
            return lstResults;
        }
    }
}
