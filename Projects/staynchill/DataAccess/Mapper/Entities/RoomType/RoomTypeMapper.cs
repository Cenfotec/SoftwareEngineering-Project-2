using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper{
     public class RoomTypeMapper: EntityMapperGeneric{
        public RoomTypeMapper() : base(dB_PR_BASE_NAME: "TIPO_HABITACION") { }

        public SqlOperation GetRetriveAllByIdStatement(int id)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_ALL_TIPO_HABITACION_BYID_PR" };
            operation.AddIntParam("FK_HOTEL", id);
            return operation;
        }
    }
}
