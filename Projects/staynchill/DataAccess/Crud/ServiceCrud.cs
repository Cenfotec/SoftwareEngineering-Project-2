using DataAccess.Dao;
using DataAccess.Mapper;
using DataAccess.Mapper.Entities.Services;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class ServiceCrud : CrudFactory
    {
        public ServiceCrud() : base(entityObjectMapper: new ServiceObjectMapper(), entityMapperGeneric: new ServiceMapper()) { }

        public List<Service> RetrieveAllByHotel(int idHotel)
        {
            try
            {
                ServiceMapper serviceMapper = new ServiceMapper();
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        serviceMapper.GetRetriveAllByIdStatement(idHotel)
                    );

                if (lstResult.Count <= 0) return default(List<Service>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Service>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }
    }
}
