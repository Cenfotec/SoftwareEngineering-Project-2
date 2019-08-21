using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper {
    public class CheckMapper : EntityMapperGeneric {
        public CheckMapper(): base(dB_PR_BASE_NAME: "CHECK") {}

        public SqlOperation GetActionCheckStatement(ActionCheck action)
        {
            var operation = new SqlOperation { ProcedureName = $"REALIZAR_CHECK_PR" };
            operation.AddIntParam("FK_SUBRESERVACION", action.FkSubReservacion);
            operation.AddVarcharParam("ACTION", action.Action);
            return operation;
        }

        public SqlOperation GetValidatePaysStatement(int idSubReservation)
        {
            var operation = new SqlOperation { ProcedureName = "VALIDATE_PAYS" };
            operation.AddIntParam("ID_SUBRESERVACION", idSubReservation);

            return operation;
        }

        public SqlOperation GetDateOutStatement(int fkSubReservacion)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DATE_CHECK_OUT" };
            operation.AddIntParam("FK_SUBRESERVACION", fkSubReservacion);
            return operation;
        }

        public SqlOperation GetChangeOutStatement(int fkSubReservacion)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CHANGE_CHECK_OUT" };
            operation.AddIntParam("FK_SUBRESERVACION", fkSubReservacion);
            return operation;
        }

        public SqlOperation GetDeleteCarStatement(int fkCarrito)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DELETE_CAR_X_FINAL_PAY" };
            operation.AddIntParam("FK_CARRITO", fkCarrito);
            return operation;
        }

        public SqlOperation GetSubReservacionStatement(string userName)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIOS_CHAT_PR" };
            operation.AddVarcharParam("USERNAME", userName);
            return operation;
        }

    }
    
}
