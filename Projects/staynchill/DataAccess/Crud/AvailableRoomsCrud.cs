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
    public class AvailableRoomsCrud : CrudFactory
    {
        public AvailableRoomsCrud() : base(entityObjectMapper: new AvailableRoomsObjectMapper(), 
            entityMapperGeneric: new AvailableRoomsMapper())
        {
        }

        public List<AvailableRooms> RetrieveAll<AvailableRooms>
            (int idHotel, int cantPersonas, DateTime checkin, DateTime checkout)
        {
            try
            {
                AvailableRoomsMapper armapper = new AvailableRoomsMapper();
                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure
                    (
                    armapper.GetRetriveAllStatement(idHotel, cantPersonas, checkin, checkout)
                    );

                if (lstResult.Count <= 0) return default(List<AvailableRooms>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<AvailableRooms>().ToList();

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }

    }
}
