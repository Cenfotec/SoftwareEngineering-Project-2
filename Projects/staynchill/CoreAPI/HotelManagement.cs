using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class HotelManagement
    {
        private HotelCrud crudHotel;

        public HotelManagement() => crudHotel = new HotelCrud();

        public void Create(Hotel hotel)
        {
            try {
                hotel.Id = 0;
                hotel.State = "Disabled";
                hotel.Date = DateTime.Now;
                hotel.RequestState = "Pending";
                hotel.Type = "Hotel";

                if (hotel.BusinessName == null)
                {
                    hotel.BusinessName = "N/A";
                }

                if (hotel.BusinessChain == null)
                {
                    hotel.BusinessChain = "N/A";
                }

                if (hotel.Value == null)
                {
                    hotel.Value = "N/A";
                }
                var vHotel = RetrieveById(hotel);
                if(vHotel == null)
                {
                    crudHotel.Create(hotel);
                } else
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Hotel> RetrieveAll() => crudHotel.RetrieveAll<Hotel>();

        public List<Hotel> RetrieveAllByUser(string user) => crudHotel.RetrieveAllByUser(user);

        public Hotel RetrieveById(Hotel hotel) => crudHotel.Retrieve<Hotel>(hotel);

        public CommissionHotel getCommision(int hotel) => crudHotel.getCommission(hotel);
        
        public void Update(Hotel hotel) => crudHotel.Update(hotel);

        public void Delete(Hotel hotel) => crudHotel.Delete(hotel);

        public void AsociarHotelAdmin(int fkHotel, string correo) => crudHotel.AsociarHotelAdmin(fkHotel, correo);

        public List<Hotel> RetrieveAllAdministrador() => crudHotel.RetrieveAllAdministrador();

        public List<Hotel> RetrieveAllByFiltro(HotelFiltro hotelFiltro)
        {
            hotelFiltro.HotelNombre = hotelFiltro.HotelNombre ?? "";

            return crudHotel.RetrieveAllByFiltro(hotelFiltro);
        }









        public async Task<List<object>> RetrieveAllByFiltroV2(HotelFiltro hotelFiltro) {
            hotelFiltro.HotelNombre = hotelFiltro.HotelNombre ?? "";
            var roomsManagement = new AvailableRoomsManagement();
            var hoteles = crudHotel.RetrieveAllByFiltro(hotelFiltro);
            Task<List<AvailableRooms>>[] tasks = new Task<List<AvailableRooms>>[hoteles.Count];

            Task<List<AvailableRooms>> getAvailableRooms(int idHotel,
            int cantPersonas,
            DateTime checkin,
            DateTime checkout) {
                return Task.Run(() => roomsManagement.RetrieveAll(idHotel, cantPersonas, checkin, checkout));
            }

            for(int ctr = 0; ctr < hoteles.Count; ctr++) {
                var hotel = hoteles[ctr];
                tasks[ctr] = Task.Run(async () => {
                    // execute get rooms
                    return await getAvailableRooms(hotel.Id, hotelFiltro.TipoHabitacionPersonas, hotelFiltro.FechaInicio, hotelFiltro.FechaFin);
                });
            }


            Task.WaitAll(tasks.ToArray());
            var hotelesResult = new List<object>(hoteles.Count);

            for (int i = 0; i < tasks.Length; i++) {
                hotelesResult.Add(new {
                    hotel = hoteles[i],
                    availableRooms = tasks[i].Result
                });
            }

            return hotelesResult;
        }

        public async Task SendMembershipEmail(CommissionHotel commissionHotel, User user, decimal totalPrice) => await crudHotel.SendMembershipEmail(commissionHotel, user, totalPrice);
    }
}
