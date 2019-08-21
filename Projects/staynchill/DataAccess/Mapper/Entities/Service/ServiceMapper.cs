using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ServiceMapper : EntityMapperGeneric
    {
        public ServiceMapper() : base(dB_PR_BASE_NAME: "SERVICE") { }

        public SqlOperation GetRetriveAllByIdStatement(int idHotel)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_SERVICE_BY_HOTEL_PR" };
            operation.AddIntParam("FK_Hotel", idHotel);
            return operation;
        }
    }
}
