 using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper {
    public class RolMapper : EntityMapperGeneric {
        public RolMapper() : base(dB_PR_BASE_NAME: "ROLES") {}

        public SqlOperation GetAssociateStatement(Rol rol)
        {
            var operation = new SqlOperation
            {
                ProcedureName = $"CRE_ROLES_USUARIOS_PR"
            };
            operation.AddVarcharParam("NOMBRE", rol.Name);
            operation.AddIntParam("FK_HOTEL ", rol.Hotel);
            operation.AddVarcharParam("PERMISOS_STRING", rol.PermisosString);

            return operation;
        }

        public SqlOperation GetRetriveAllByIdHotelStatement(int idHotel)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_ALL_ROLES_BY_ID_HOTEL_PR" };
            operation.AddIntParam("FK_HOTEL", idHotel);
            return operation;
        }

        public SqlOperation Validate(Rol rol)
        {
            var operation = new SqlOperation { ProcedureName = $"VAL_ROLES_PR" };
            operation.AddVarcharParam("NOMBRE", rol.Name);
            operation.AddIntParam("FK_HOTEL", rol.Hotel);
            return operation;
        }

        public SqlOperation GetRetriveAllPermisosStatement()
        {
            var operation = new SqlOperation { ProcedureName = $"RET_ALL_VISTAS_PR" };
            return operation;
        }

        public SqlOperation GetRetrieveAllPermisosByUsuario(string correo)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_ALL_ROLES_BY_ID_USUARIO_PR" };
            operation.AddVarcharParam("CORREO", correo);
            return operation;
        }

        public SqlOperation GetRetrieveAllByUser(Rol rol)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_ALL_NOMBRE_ROLES_BY_ID_USUARIO_PR" };
            operation.AddVarcharParam("CORREO", rol.Name);
            return operation;
        }

        public SqlOperation GetDeleteRolStatement(Rol rol)
        {
            var operation = new SqlOperation { ProcedureName = $"DEL_ROLES_PR" };
            operation.AddVarcharParam("NOMBRE", rol.Name);
            operation.AddIntParam("FK_HOTEL", rol.Hotel);
            return operation;
        }
    }
}
