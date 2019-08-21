using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class RoomObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_ROOM_TYPE = "FK_TIPO_HABITACION";
        private const string DB_COL_ROOM_TYPE_NAME = "FK_NOMBRE_TIPO_HABITACION";
        private const string DB_COL_ROOM_NUMBER = "NUM_HABITACION";
        private const string DB_COL_DESCRIPTION = "DESCRIPCION";
        private const string DB_COL_STATE = "ESTADO";
        private const string DB_COL_VALUE = "VALOR";
        private const string DB_COL_TYPE = "TIPO";
        private const string DB_COL_HOTEL = "FK_HOTELES";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var room = new Room()
            {
                Id = GetIntValue(row, DB_COL_ID),
                RoomType = GetIntValue(row, DB_COL_ROOM_TYPE),
                RoomTypeName = GetStringValue(row, DB_COL_ROOM_TYPE_NAME),
                RoomNumber = GetIntValue(row, DB_COL_ROOM_NUMBER),
                Description = GetStringValue(row, DB_COL_DESCRIPTION),
                State = GetStringValue(row, DB_COL_STATE),
                IdHotel = GetIntValue(row, DB_COL_HOTEL),
                Value = GetStringValue(row, DB_COL_VALUE),
                Type = GetStringValue(row, DB_COL_TYPE)
            };

            return room;
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var room = BuildObject(row);
                lstResults.Add(item: room);
            }

            return lstResults;
        }
    }
}
