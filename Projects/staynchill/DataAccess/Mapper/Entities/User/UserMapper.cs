using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper {
    public class UserMapper : EntityMapperGeneric {
        //Preguntar si este nombre esta bien
        public UserMapper(): base(dB_PR_BASE_NAME: "USUARIO") {}

        public SqlOperation GetRetriveAllByIdStatement(int id, string cedula) 
        {
            var operation = new SqlOperation { ProcedureName = $"RET_ALL_BY_ID_{DB_PR_BASE_NAME}_PR" };
            operation.AddIntParam("ID" , id);
            operation.AddVarcharParam("CEDULA", cedula);
            return operation;
        }

        public SqlOperation GetRetriveAllSubAdministradorByHotelStatement(int idHotel)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_ALL_SUBADMINISTRADOR_BY_HOTEL_PR" };
            operation.AddIntParam("ID_HOTEL", idHotel);
            return operation;
        }

        public SqlOperation GetRetriveByCorreoStatement(string correo)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_USUARIO_PR" };
            operation.AddVarcharParam("CORREO", correo);
            return operation;
        }

	    public SqlOperation Validate(string correo)
        {
            var operation = new SqlOperation { ProcedureName = $"VAL_USUARIO_PR" };
            operation.AddVarcharParam("CORREO", correo);
            return operation;
        }

        public SqlOperation UpdateRecoveredPassword(string correo, string contrasenna)
        {
            var operation = new SqlOperation { ProcedureName = $"UPD_CONTRASENNA_USUARIO_PR" };
            operation.AddVarcharParam("CORREO", correo);
            operation.AddVarcharParam("CONTRASENNA", contrasenna);
            return operation;
        }

        public SqlOperationGeneric CreateAdminHotel<TEntity>(TEntity entity) where TEntity : class
        {
            var operation = new SqlOperationGeneric
            {
                ProcedureName = $"CRE_USUARIO_ADMINISTRADOR_HOTEL_PR"
            };
            operation.AddParams(entity);
            return operation;
        }

        public SqlOperationGeneric CreateSubAdminHotel<TEntity>(TEntity entity) where TEntity : class
        {
            var operation = new SqlOperationGeneric
            {
                ProcedureName = $"CRE_USUARIO_SUBADMINISTRADOR_HOTEL_PR"
            };
            operation.AddParams(entity);
            return operation;
        }

        public SqlOperationGeneric CreateFinal<TEntity>(TEntity entity) where TEntity : class
        {
            var operation = new SqlOperationGeneric
            {
                ProcedureName = $"CRE_USUARIO_FINAL_PR"
            };
            operation.AddParams(entity);
            return operation;
        }
    }
}