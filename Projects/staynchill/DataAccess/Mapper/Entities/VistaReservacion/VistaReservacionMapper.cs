 using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper {
    public class VistaReservacionMapper : EntityMapperGeneric {
        public VistaReservacionMapper() : base(dB_PR_BASE_NAME: "VISTA_RESERVACION") {}
 
        public SqlOperation GetRetriveAllPermisosStatement(int id)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_ALL_VISTA_RESERVACION_PR" };
            operation.AddIntParam("FK_USUARIO", id);
            return operation;
        } 
    }
}
