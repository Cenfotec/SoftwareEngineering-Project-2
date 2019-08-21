using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class RolCrud : CrudFactory
    {
        public RolCrud() : base(entityObjectMapper: new RolObjectMapper(), entityMapperGeneric: new RolMapper()) { }

        RolMapper rolMapper = new RolMapper();

        public void Associate(Rol rol)
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = rolMapper.GetAssociateStatement(rol);
                instance.ExecuteProcedure(operation);
            }
            catch (Exception e)
            {
                ManageException(e);
            }
        }

        public List<Rol> RetrieveAllByIdHotel(int idHotel)
        {

            try
            {
                var rolMapper = new RolMapper();
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        rolMapper.GetRetriveAllByIdHotelStatement(idHotel)
                    );

                if (lstResult.Count <= 0) return default(List<Rol>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Rol>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }

        public T Validate<T>(Rol rol)
        {

            try
            {
                var instance = SqlDao.GetInstance();
                var operation = rolMapper.Validate(rol);
                var lstResult = instance.ExecuteQueryProcedure(operation);

                if (lstResult.Count <= 0) return default(T);

                var objs = EntityObjectMapper.BuildObjects(lstResult);

                return objs.Cast<T>().ToList()[0];

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return default(T);
        }

        public List<Rol> RetrieveAllPermisos()
        {

            try
            {

                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure(rolMapper.GetRetriveAllPermisosStatement());

                if (lstResult.Count <= 0) return default(List<Rol>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Rol>().ToList();

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }

        public List<Rol> RetrieveAllPermisosByUsuario(User user)
        {

            try
            {
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        rolMapper.GetRetrieveAllPermisosByUsuario(user.Correo)
                    );

                if (lstResult.Count <= 0) return default(List<Rol>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Rol>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }

        public List<Rol> RetrieveAllByUser(Rol rol)
        {

            try
            {
                var rolMapper = new RolMapper();
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        rolMapper.GetRetrieveAllByUser(rol)
                    );

                if (lstResult.Count <= 0) return default(List<Rol>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Rol>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }

        public bool DeleteRol(Rol rol)
        {

            try
            {

                var operation = rolMapper.GetDeleteRolStatement(rol);
                var instance = SqlDao.GetInstance();
                instance.ExecuteProcedure(operation);

                return true;

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return false;
        }
    }
}
