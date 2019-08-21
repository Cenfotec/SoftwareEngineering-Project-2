using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class AvailableRoomsMapper : EntityMapperGeneric
    {
        public AvailableRoomsMapper() : base(dB_PR_BASE_NAME: "AVAILABLE_ROOMS") { }

        public SqlOperation GetRetriveAllStatement(int idHotel, int cantPersonas, DateTime checkin, DateTime checkout)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_AVAILABLE_ROOMS_PR" };
            operation.AddIntParam("HOTEL_ID", idHotel);
            operation.AddIntParam("TIPO_HABITACION_PERSONAS", cantPersonas);
            operation.AddDateParam("FECHA_INICIO", checkin);
            operation.AddDateParam("FECHA_FIN", checkout);

            return operation;
        }
    }
}