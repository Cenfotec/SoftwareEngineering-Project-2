using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class ReservationInvoice
    {
        public string CorreoUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string NombreHotel { get; set; }
        public string TipoHabitacion { get; set; }
        public int NumHabitacion { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public int CantidadNoches { get; set; }
        public string PrecioTotal { get; set; }
    }
}
