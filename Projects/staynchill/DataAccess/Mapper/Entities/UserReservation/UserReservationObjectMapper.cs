using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class UserReservationObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_ID_SUBRESERVACION = "ID_SUBRESERVACION";
        private const string DB_COL_ID_CARRITO = "ID_CARRITO";
        private const string DB_COL_HOTEL = "FK_HOTEL";
        private const string DB_COL_QRCODE = "QR_VALUE";
        private const string DB_COL_QRSTATE = "QR_ESTADO";
        private const string DB_COL_STATE = "ESTADO";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var ureservation = new UserReservation
            {
                Id = GetIntValue(row, DB_COL_ID),
                Subreservacion = GetIntValue(row, DB_COL_ID_SUBRESERVACION),
                Carrito = GetIntValue(row, DB_COL_ID_CARRITO),
                Hotel = GetIntValue(row, DB_COL_HOTEL),
                QRCode = GetStringValue(row, DB_COL_QRCODE),
                QRState = GetStringValue(row, DB_COL_QRSTATE),
                State = GetStringValue(row, DB_COL_STATE)
            };
            return ureservation;
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var uReservation = BuildObject(row);
                lstResults.Add(item: uReservation);
            }

            return lstResults;
        }
    }
}
