using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper {
    public class AdvertisementObjectMapper : ObjectMapper {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_FK_HOTEL = "FK_HOTEL";
        private const string DB_COL_FK_TIPO_HABITACION = "FK_TIPO_HABITACION";
        private const string DB_COL_FK_PRODUCTO = "FK_PRODUCTO";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_DESCRIPCION = "DESCRIPCION";
        private const string DB_COL_VALOR = "VALOR";
        private const string DB_COL_CUPOS = "CUPOS";
        private const string DB_COL_FECHA_INICIO = "FECHA_INICIO";
        private const string DB_COL_FECHA_FIN = "FECHA_FIN";
        private const string DB_COL_ESTADO = "ESTADO";

        public override BaseEntity BuildObject(Dictionary<string, object> row) {

            return new Advertisement {
                Id = GetIntValue(row, DB_COL_ID),
                FkHotel = GetIntValue(row, DB_COL_FK_HOTEL),
                FkRoomType = GetIntValue(row, DB_COL_FK_TIPO_HABITACION),
                FkProduct = GetIntValue(row, DB_COL_FK_PRODUCTO),
                Name = GetStringValue(row, DB_COL_NOMBRE),
                Description = GetStringValue(row, DB_COL_DESCRIPCION),
                Value = GetDecimalValue(row, DB_COL_VALOR),
                RemainingOffers = GetIntValue(row, DB_COL_CUPOS),
                StartDate = GetDateValue(row, DB_COL_FECHA_INICIO),
                EndDate = GetDateValue(row, DB_COL_FECHA_FIN),
                State = GetStringValue(row, DB_COL_ESTADO)
            };

        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var advertisement = BuildObject(row);
                lstResults.Add(item: advertisement);
            }

            return lstResults;
        }
    }
}
