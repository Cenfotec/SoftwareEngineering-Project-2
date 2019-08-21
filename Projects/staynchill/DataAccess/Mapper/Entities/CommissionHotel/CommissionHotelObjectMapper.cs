using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;

namespace DataAccess.Mapper{
    public class CommissionHotelObjectMapper : ObjectMapper{
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NOMBRE";
        private const string DB_COL_DESCRIPTION = "DESCRIPCION";
        private const string DB_COL_LEGAL_NUMBER = "CEDULA_JURIDICA";
        private const string DB_COL_BUSINESS_NAME = "NOMBRE_EMPRESA";
        private const string DB_COL_BUSINES_CHAIN = "NOMBRE_CADENA";
        private const string DB_COL_EMAIL = "CORREO_HOTEL";
        private const string DB_COL_PHONE_NUMBER = "TELEFONO";
        private const string DB_COL_STARS = "NUM_ESTRELLAS";
        private const string DB_COL_HOTEL_STATE = "ESTADO_HOTEL";
        //UBICACION
        private const string DB_COL_LATITUDE = "LATITUD";
        private const string DB_COL_LONGITUDE = "LONGITUD";
        private const string DB_COL_PROVINCE = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRICT = "DISTRITO";
        //SOLICITUD
        private const string DB_COL_DATE = "FECHA";
        private const string DB_COL_DAILY_SALES = "VENTAS_DIA";
        private const string DB_COL_MONTHLY_SALES = "VENTAS_MES";
        private const string DB_COL_REQUEST_STATE = "ESTADO_SOLICITUD";
        private const string DB_COL_EMAIL_USER = "CORREO";
        //IMAGEN
        private const string DB_COL_VALUE = "VALOR";
        private const string DB_COL_TYPE = "TIPO";
        private const string DB_COL_COMMISSION = "PORCENTAJE";


        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {

            var hotel = new CommissionHotel
            {
                Id = GetIntValue(row, DB_COL_ID),
                Name = GetStringValue(row, DB_COL_NAME),
                Description = GetStringValue(row, DB_COL_DESCRIPTION),
                LegalNumber = GetStringValue(row, DB_COL_LEGAL_NUMBER),
                BusinessName = GetStringValue(row, DB_COL_BUSINESS_NAME),
                BusinessChain = GetStringValue(row, DB_COL_BUSINES_CHAIN),
                HotelEmail = GetStringValue(row, DB_COL_EMAIL),
                PhoneNumber = GetStringValue(row, DB_COL_PHONE_NUMBER),
                Stars = GetStringValue(row, DB_COL_STARS),
                State = GetStringValue(row, DB_COL_HOTEL_STATE),
                //UBICACION
                Latitude = GetStringValue(row, DB_COL_LATITUDE),
                Longitude = GetStringValue(row, DB_COL_LONGITUDE),
                Province = GetStringValue(row, DB_COL_PROVINCE),
                Canton = GetStringValue(row, DB_COL_CANTON),
                District = GetStringValue(row, DB_COL_DISTRICT),
                //SOLICITUD
                Date = GetDateValue(row, DB_COL_DATE),
                DailySales = GetDecimalValue(row, DB_COL_DAILY_SALES),
                MonthlySales = GetDecimalValue(row, DB_COL_MONTHLY_SALES),
                Email = GetStringValue(row, DB_COL_EMAIL_USER),
                RequestState = GetStringValue(row, DB_COL_REQUEST_STATE),
                //IMAGEN
                Value = GetStringValue(row, DB_COL_VALUE),
                Type = GetStringValue(row, DB_COL_TYPE),
                Commission = GetDecimalValue(row, DB_COL_COMMISSION)
            };

            return hotel;
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var hotel = BuildObject(row);
                lstResults.Add(item: hotel);
            }

            return lstResults;
        }
    }
}