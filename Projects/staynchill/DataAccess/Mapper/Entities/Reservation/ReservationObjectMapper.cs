using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class ReservationObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_FK_USUARIO = "FK_USUARIO";
        private const string DB_COL_FK_HOTEL = "FK_HOTEL";
        private const string DB_COL_FECHA_INCIO = "FECHA_INCIO";
        private const string DB_COL_FECHA_FIN = "FECHA_FIN";
        private const string DB_COL_PRECIO = "PRECIO";
        private const string DB_COL_FK_HABITACION = "FK_HABITACION";
        private const string DB_COL_FK_RESERVACION = "FK_RESERVACION";
        private const string DB_COL_FK_SUBRESERVACION = "FK_SUBRESERVACION";
        private const string DB_COL_ESTADO = "ESTADO";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {

            return new Reservation
            {
                Id = GetIntValue(row, DB_COL_ID),
                FkUser = GetIntValue(row, DB_COL_FK_USUARIO),
                FkHotel = GetIntValue(row, DB_COL_FK_HOTEL),
                StartDate = GetDateValue(row, DB_COL_FECHA_INCIO),
                EndDate = GetDateValue(row, DB_COL_FECHA_FIN),
                Price = GetDecimalValue(row, DB_COL_PRECIO),
                FKRoom = GetIntValue(row, DB_COL_FK_HABITACION),
                FkReservation = GetIntValue(row, DB_COL_FK_RESERVACION),
                FkSubreservation = GetIntValue(row, DB_COL_FK_SUBRESERVACION),
                State = GetStringValue(row, DB_COL_ESTADO)
            };

        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var reservation = BuildObject(row);
                lstResults.Add(item: reservation);
            }

            return lstResults;
        }
    }
}
