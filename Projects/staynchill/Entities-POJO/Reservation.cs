using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class BaseReservation  : BaseEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        [DbColumn("FK_USUARIO")]
        public int FkUser { get; set; }
        [DbColumn("FK_HOTEL")]
        public int FkHotel { get; set; }
        [DbColumn("FECHA_INCIO")]
        public DateTime StartDate { get; set; }
        [DbColumn("FECHA_FIN")]
        public DateTime EndDate { get; set; }
        [DbColumn("PRECIO")]
        public decimal Price { get; set; }
        [DbColumn("ESTADO")]
        public string State { get; set; }
    }

    public class Reservation : BaseReservation
    {
        [DbColumn("FK_HABITACION")]
        public int FKRoom { get; set; }
        [DbColumn("FK_RESERVACION")]
        public int FkReservation { get; set; }
        [DbColumn("FK_SUBRESERVACION")]
        public int FkSubreservation { get; set; }
    }
}
