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
    public class VistaReservacionCrud : CrudFactory
    {
        public VistaReservacionCrud() : base(entityObjectMapper: new VistaReservacionObjectMapper(), entityMapperGeneric: new VistaReservacionMapper()) { }

        VistaReservacionMapper vistaReservacionMapper = new VistaReservacionMapper();

        public List<VistaReservacion> RetrieveAllPermisos(int id)
        {

            try
            {

                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure(vistaReservacionMapper.GetRetriveAllPermisosStatement(id));

                if (lstResult.Count <= 0) return default(List<VistaReservacion>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<VistaReservacion>().ToList();

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }
    }
}
