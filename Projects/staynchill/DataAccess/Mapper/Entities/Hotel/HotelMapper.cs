using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper{
    public class HotelMapper : EntityMapperGeneric{
        public HotelMapper() : base(dB_PR_BASE_NAME : "HOTEL"){}

        public SqlOperation GetRetriveAllByIdStatement(string user)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_HOTEL_BY_USER_PR" };
            operation.AddVarcharParam("USER", user);
            return operation;
        }

        public SqlOperation GetAsociarHotelAdminStatement(int fkHotel, string correo)
        {
            var operation = new SqlOperation { ProcedureName = $"ASO_HOTEL_ADMIN" };
            operation.AddIntParam("FK_HOTEL", fkHotel);
            operation.AddVarcharParam("CORREO", correo);
            return operation;
        }

        public SqlOperation GetRetriveAllAdministradorStatement()
        {
            var operation = new SqlOperation { ProcedureName = $"RET_ALL_HOTELES_PR" };
            return operation;
        }

        public SqlOperation GetCommissionStatement(int hotel)
        {
            var operation = new SqlOperation { ProcedureName = $"GET_COMISION_HOTEL_PR" };
            operation.AddIntParam("FK_HOTEL",hotel);
            return operation;
        }

        public SqlOperation GetRetrieveAllByFiltroStatement(HotelFiltro hotelFiltro)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_ALL_HOTELES_DISPONIBLES_PR" };
            operation.AddVarcharParam("HOTEL_NOMBRE", hotelFiltro.HotelNombre);
            operation.AddIntParam("TIPO_HABITACION_PERSONAS", hotelFiltro.TipoHabitacionPersonas);
            operation.AddDateParam("FECHA_INICIO", hotelFiltro.FechaInicio);
            operation.AddDateParam("FECHA_FIN", hotelFiltro.FechaFin);
            return operation;
        }
    }
}