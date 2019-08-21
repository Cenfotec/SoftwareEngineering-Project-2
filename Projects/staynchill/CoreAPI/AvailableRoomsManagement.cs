using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class AvailableRoomsManagement
    {
        private AvailableRoomsCrud availableRoomsCrud;

        public AvailableRoomsManagement() => availableRoomsCrud = new AvailableRoomsCrud();

        public List<AvailableRooms> RetrieveAll
            (int idHotel,
            int cantPersonas,
            DateTime checkin,
            DateTime checkout)
        {
            return availableRoomsCrud.RetrieveAll<AvailableRooms>(idHotel, cantPersonas, checkin, checkout);
        }
    }
}
