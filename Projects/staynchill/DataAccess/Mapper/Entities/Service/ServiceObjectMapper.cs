using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;

namespace DataAccess.Mapper.Entities.Services
{
    public class ServiceObjectMapper : ObjectMapper
    {
        private string DB_COL_ID = "ID";
        private string DB_COL_HOTEL = "FK_HOTEL";
        private string DB_COL_NAME = "NOMBRE";
        private string DB_COL_DESCRIPTION = "DESCRIPCION";
        private string DB_COL_LEGAL_NUMBER = "CEDULA_JURIDICA";
        private string DB_COL_TYPE = "TIPO";
        private string DB_COL_OPENING_SCHEDULE = "HORARIO_APERTURA";
        private string DB_COL_CLOSING_SCHEDULE = "HORARIO_CIERRE";
        private string DB_COL_STATE = "ESTADO";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var service = new Service
            {
                Id = GetIntValue(row, DB_COL_ID),
                Hotel = GetIntValue(row, DB_COL_HOTEL),
                Name = GetStringValue(row, DB_COL_NAME),
                Description = GetStringValue(row, DB_COL_DESCRIPTION),
                LegalNumber = GetIntValue(row, DB_COL_LEGAL_NUMBER),
                Type = GetStringValue(row, DB_COL_TYPE),
                OpeningSchedule = GetDateValue(row, DB_COL_OPENING_SCHEDULE),
                ClosingSchedule = GetDateValue(row, DB_COL_CLOSING_SCHEDULE),
                State = GetStringValue(row, DB_COL_STATE)
            };

            return service;
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var service = BuildObject(row);
                lstResults.Add(item: service);
            }

            return lstResults;
        }
    }
}
