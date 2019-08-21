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
    public class RoomManagement
    {
        private RoomCrud roomCrud;

        public RoomManagement() => roomCrud = new RoomCrud();

        public void Create(Room room) {
            try {
                if (room.Value == null)
                {
                    room.Value = "N/A";
                }
                room.RoomTypeName = "N/A";
                room.Type = "Habitación";

                var vRoom = RetrieveByRoomNumber(room);
                if(vRoom == null)
                {
                    roomCrud.Create(room);
                } else
                {
                    throw new BussinessException(5);
                }
            }
            catch (Exception ex) {
                ExceptionManager.GetInstance().Process(ex);
            }
         }

        public List<Room> RetrieveAll() => roomCrud.RetrieveAll<Room>();

        public Room RetrieveById(Room room) => roomCrud.Retrieve<Room>(room);

        public List<Room> RetrieveAllById(int hotel) => roomCrud.RetrieveAllById(hotel);

        public void Update(Room room) => roomCrud.Update(room);

        public void Delete(Room room) => roomCrud.Delete(room);

        public Room RetrieveByRoomNumber(Room room) => roomCrud.RetrieveByRoomNumber<Room>(room);

    }
}
