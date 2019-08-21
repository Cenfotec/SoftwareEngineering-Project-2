using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;

namespace DataAccess.Mapper{
    public class RoomTypeObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NOMBRE";
        private const string DB_COL_DESCRIPTION = "DESCRIPCION";
        private const string DB_COL_AMOUNT_PEOPLE = "CANT_PERSONAS";
        private const string DB_COL_AMOUNT_BEDS = "CANT_CAMAS";
        private const string DB_COL_PETS_ALLOWED = "PERMITE_MASCOTAS";
        private const string DB_COL_PRICE = "PRECIO";
        private const string DB_COL_STATE = "ESTADO";
        private const string DB_COL_FK_HOTEL = "FK_HOTEL";
        private const string DB_COL_HORARIO_CHECK_IN = "HORARIO_CHECK_IN";
        private const string DB_COL_HORARIO_CHECK_OUT = "HORARIO_CHECK_OUT";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var roomType = new RoomType()
            {
                Id = GetIntValue(row, DB_COL_ID),
                Name = GetStringValue(row, DB_COL_NAME),
                Description = GetStringValue(row, DB_COL_DESCRIPTION),
                AmountPeople= GetIntValue(row, DB_COL_AMOUNT_PEOPLE),
                AmountBeds = GetIntValue(row, DB_COL_AMOUNT_BEDS),
                PetsAllowed = GetStringValue(row, DB_COL_PETS_ALLOWED),
                Price = GetDecimalValue(row, DB_COL_PRICE),
                IdHotel = GetIntValue(row,DB_COL_FK_HOTEL),
                State = GetStringValue(row, DB_COL_STATE),
                HorarioCheckIn = GetDateValue(row, DB_COL_HORARIO_CHECK_IN),
                HorarioCheckOut = GetDateValue(row, DB_COL_HORARIO_CHECK_OUT)
            };

           return roomType;
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var roomType = BuildObject(row);
                lstResults.Add(item: roomType);
            }

            return lstResults;
        }
    }
}
