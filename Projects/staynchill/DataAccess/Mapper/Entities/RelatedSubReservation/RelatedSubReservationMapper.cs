using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class RelatedSubReservationMapper : EntityMapperGeneric
    {
        public RelatedSubReservationMapper() : base(dB_PR_BASE_NAME: "") { }

        public SqlOperation GetRetriveAllStatement(int idSubReservation)
        {
            var operation = new SqlOperation { ProcedureName = "RET_SUB_RESERVACIONES_ASOCIADOS_A_RESERVACION_BY_SUB_RESERVACION_ID_PR" };
            operation.AddIntParam("ID_SUBRESERVACION", idSubReservation);

            return operation;
        }
    }
}
