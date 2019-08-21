using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper {
    public class CodeMapper : EntityMapperGeneric {
        //Preguntar si este nombre esta bien
        public CodeMapper(): base(dB_PR_BASE_NAME: "CODIGO") {}
        
        public SqlOperation CodeStatement(string email, string code)
        {
            var operation = new SqlOperation { ProcedureName = $"CRE_CODIGO_CONFIRMACION_PR" };
            operation.AddVarcharParam("CORREO", email);
            operation.AddVarcharParam("CODIGO", code);
            return operation;
        }

        public SqlOperation GetCodeStatement(string correo)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_CODIGO_CONFIRMACION_PR" };
            operation.AddVarcharParam("CORREO", correo);
            return operation;
        }
        
    }
}