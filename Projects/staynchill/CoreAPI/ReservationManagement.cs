using DataAccess.Crud;
using Entities_POJO;
using System.Collections.Generic;

namespace CoreAPI
{
    public class ReservationManagement
    {

        private ReservationCrud reservationCrud;

        public ReservationManagement() => reservationCrud = new ReservationCrud();

        public Reservation Create(Reservation reservation) => reservationCrud.CreateReservationReturn<Reservation>(reservation);

        public List<Reservation> RetrieveAll() => reservationCrud.RetrieveAll<Reservation>();

        public List<Reservation> RetrieveAllById(int user)
        {
            var reservaciones = new List<Reservation>();
            reservaciones = reservationCrud.RetrieveAllById(user);
            return reservaciones;
        }

        public Reservation RetrieveById(Reservation reservation) => reservationCrud.Retrieve<Reservation>(reservation);

        public void Update(Reservation reservation) => reservationCrud.Update(reservation);

        public void Delete(Reservation reservation) => reservationCrud.Delete(reservation);

        public Reservation CreateSubreservation(Reservation reservation, User user) => reservationCrud.CreateSubreservation<Reservation>(reservation, user);

        public async System.Threading.Tasks.Task SendInvoiceAsync(ReservationInvoice reservationInvoice) => await reservationCrud.SendInvoice(reservationInvoice);
    }
}
