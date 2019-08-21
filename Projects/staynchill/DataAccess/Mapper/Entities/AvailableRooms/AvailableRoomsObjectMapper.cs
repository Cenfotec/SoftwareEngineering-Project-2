using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class AvailableRoomsObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_ROOM_TYPE = "FK_TIPO_HABITACION";
        private const string DB_COL_ROOM_NUMBER = "NUM_HABITACION";
        private const string DB_COL_DESCRIPTION = "DESCRIPCION";
        private const string DB_COL_VALUE = "VALOR";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_DESCRIPCION_TH = "DESCRIPCION_TH";
        private const string DB_COL_CANT_PERSONAS = "CANT_PERSONAS";
        private const string DB_COL_CANT_CAMAS = "CANT_CAMAS";
        private const string DB_COL_PERMITE_MASCOTAS = "PERMITE_MASCOTAS";
        private const string DB_COL_PRECIO = "PRECIO";
        private const string DB_COL_HOTEL = "HOTEL";
        private const string DB_COL_HORARIO_CHECK_IN = "HORARIO_CHECK_IN";
        private const string DB_COL_HORARIO_CHECK_OUT = "HORARIO_CHECK_OUT";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var availableRooms = new AvailableRooms()
            {
                Id = GetIntValue(row, DB_COL_ID),
                RoomType = GetIntValue(row, DB_COL_ROOM_TYPE),
                RoomNumber = GetIntValue(row, DB_COL_ROOM_NUMBER),
                Description = GetStringValue(row, DB_COL_DESCRIPTION),
                Value = GetStringValue(row, DB_COL_VALUE),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                DescripcionTH = GetStringValue(row, DB_COL_DESCRIPCION_TH),
                CantPersonas = GetIntValue(row, DB_COL_CANT_PERSONAS),
                CantCamas = GetIntValue(row, DB_COL_CANT_CAMAS),
                PermiteMascotas = GetStringValue(row, DB_COL_PERMITE_MASCOTAS),
                Precio = GetDecimalValue(row, DB_COL_PRECIO),
                IdHotel = GetIntValue(row, DB_COL_HOTEL),
                HorarioCheckIn = GetDateValue(row, DB_COL_HORARIO_CHECK_IN),
                HorarioCheckOut = GetDateValue(row, DB_COL_HORARIO_CHECK_OUT)
            };
            return availableRooms;
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
