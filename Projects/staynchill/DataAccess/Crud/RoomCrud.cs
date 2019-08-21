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
    public class RoomCrud :CrudFactory
    {
        public RoomCrud() : base(entityObjectMapper: new RoomObjectMapper(), entityMapperGeneric: new RoomMapper())
        {
        }

        public List<Room> RetrieveAllById(int hotel)
        {
            var roomMapper = new RoomMapper();
            try
            {

                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        roomMapper.GetRetriveAllByIdStatement(hotel)
                    );

                if (lstResult.Count <= 0) return default(List<Room>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Room>().ToList();

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }

        public T RetrieveByRoomNumber<T>(Room room)
        {
            var roomMapper = new RoomMapper();
            try
            {

                var instance = SqlDao.GetInstance();
                var operation = roomMapper.GetRetrieveByRoomNumberStatement(room.IdHotel, room.RoomNumber);
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

    }
}
