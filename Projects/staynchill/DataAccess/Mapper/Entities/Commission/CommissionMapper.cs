using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper {
    public class CommissionMapper : EntityMapperGeneric {
        public CommissionMapper(): base(dB_PR_BASE_NAME: "COMISIONES") {}

        public SqlOperation IsAdminHotelRegistered(int fkHotel)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_IS_ADMIN_HOTEL_REGISTERED" };
            operation.AddIntParam("FK_HOTEL", fkHotel);
            return operation;
        }

        public SqlOperation GetCommissionStatement(Commission cedulaJuridicaDeHotel)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_COMMISION_BY_ID_PR" };
            operation.AddVarcharParam("PORCENTAJE", cedulaJuridicaDeHotel.Percentage);
            return operation;
        }
    }
}
