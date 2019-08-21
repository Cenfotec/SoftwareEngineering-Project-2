using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper.Entities.QRCode
{
    public class QRCodeMapper : EntityMapperGeneric
    {
        public QRCodeMapper() : base(dB_PR_BASE_NAME: "QRCODE") { }

        public SqlOperation GetRetrieveByReservationIdStatement(int idReservation)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_QRCODE_BY_RESERVACION_PR" };
            operation.AddIntParam("ID_RESERVACION", idReservation);
            return operation;
        }

        public SqlOperation GetRetrieveAllByReservationIdStatement(int idReservation)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_LLAVES_GENERADAS_BY_ID_RESERVACION_PR" };
            operation.AddIntParam("ID_RESERVACION", idReservation);
            return operation;
        }
    }
}
