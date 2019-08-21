using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class RequestMapper : EntityMapperGeneric
    {
        public RequestMapper() : base(dB_PR_BASE_NAME: "REQUEST") { }
        public SqlOperation GetRetriveAllByIdStatement(Request request)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_REQUEST_PR" };
            operation.AddIntParam("ID", request.Id);
            return operation;
        }
        

    }
}
