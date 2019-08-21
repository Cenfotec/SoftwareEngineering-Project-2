using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class InfoChatBotObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_USER = "USUARIO";
        private const string DB_COL_HOTEL = "HOTEL";
        private const string DB_COL_START_DATE = "FECHA_INCIO";
        private const string DB_COL_END_DATE = "FECHA_FIN";
        private const string DB_COL_HORARIO_IN = "HORARIO_CHECK_IN";
        private const string DB_COL_HORARIO_OUT = "HORARIO_CHECK_OUT";
        private const string DB_COL_CHECK_IN = "CHECK_IN";
        private const string DB_COL_CHECK_OUT = "CHECK_OUT";
        private const string DB_COL_ROOM_TYPE = "TIPO_HABITACION";
        private const string DB_COL_CANT_PERSONAS = "CANT_PERSONAS";
        private const string DB_COL_PRECIO = "PRECIO";
        private const string DB_COL_ROOM_NUM = "NUM_HABITACION";
        private const string DB_COL_LATITUDE = "LATITUD";
        private const string DB_COL_LONGITUDE = "LONGITUD";


        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var info = new InfoChatBot()
            {
                Id = GetIntValue(row, DB_COL_ID),
                User = GetStringValue(row, DB_COL_USER),
                Hotel = GetStringValue(row, DB_COL_HOTEL),
                StartDate = GetDateValue(row, DB_COL_START_DATE),
                EndDate = GetDateValue(row, DB_COL_END_DATE),
                HorarioIn = GetDateValue(row, DB_COL_HORARIO_IN),
                HorarioOut = GetDateValue(row, DB_COL_HORARIO_OUT),
                CheckIn = GetDateValue(row, DB_COL_CHECK_IN),
                CheckOut = GetDateValue(row, DB_COL_CHECK_OUT),
                RoomType = GetStringValue(row, DB_COL_ROOM_TYPE),
                AmountPeople = GetIntValue(row, DB_COL_CANT_PERSONAS),
                Price = GetDecimalValue(row, DB_COL_PRECIO),
                RoomNumber = GetIntValue(row, DB_COL_ROOM_NUM),
                Latitude = GetStringValue(row, DB_COL_LATITUDE),
                Longitude = GetStringValue(row, DB_COL_LONGITUDE)

            };

            return info;
            throw new Exception();
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var infoChatBot = BuildObject(row);
                lstResults.Add(item: infoChatBot);
            }

            return lstResults;
        }
    }
}
