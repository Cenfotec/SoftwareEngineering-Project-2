using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class RoomMapper : EntityMapperGeneric
    {
        public RoomMapper() : base(dB_PR_BASE_NAME: "HABITACION") { }

        public SqlOperation GetRetriveAllByIdStatement(int hotel)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_BYID_HABITACION_PR" };
            operation.AddIntParam("HOTEL", hotel);
            return operation;
        }

        public SqlOperation GetRetrieveByRoomNumberStatement(int id_hotel, int num_habitacion)
        {
            var operation = new SqlOperation { ProcedureName = "RET_HABITACION_BY_NUM_PR" };
            operation.AddIntParam("HOTEL", id_hotel);
            operation.AddIntParam("NUM_HABITACION", num_habitacion);
            return operation;
        }
    }
}