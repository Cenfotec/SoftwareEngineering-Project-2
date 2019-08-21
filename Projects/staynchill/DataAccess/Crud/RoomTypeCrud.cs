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
    public class RoomTypeCrud : CrudFactory
    {
        public RoomTypeCrud() : base(entityObjectMapper: new RoomTypeObjectMapper(), entityMapperGeneric: new RoomTypeMapper()){ }

        public List<RoomType> RetrieveAllById(int id)
        {

            try
            {
                var roomTypeMapper = new RoomTypeMapper();
                var instance = SqlDao.GetInstance();
                var operation = roomTypeMapper.GetRetriveAllByIdStatement(id);
                var lstResult = instance.ExecuteQueryProcedure(operation);

                if (lstResult.Count <= 0) return default(List<RoomType>);

                var objs = EntityObjectMapper.BuildObjects(lstResult);

                return objs.Cast<RoomType>().ToList();

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }


    }
}
