using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Advertisement : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("ID")]
        public int Id { get; set; }

        [DbColumn("FK_HOTEL")]
        public int FkHotel { get; set; }

        [DbColumn("FK_TIPO_HABITACION")]
        public int FkRoomType { get; set; }

        [DbColumn("FK_PRODUCTO")]
        public int FkProduct { get; set; }

        [DbColumn("NOMBRE")]
        public string Name { get; set; }

        [DbColumn("DESCRIPCION")]
        public string Description { get; set; }

        [DbColumn("VALOR")]
        public decimal Value { get; set; }

        [DbColumn("CUPOS")]
        public int RemainingOffers { get; set; }

        [DbColumn("FECHA_INICIO")]
        public DateTime StartDate { get; set; }

        [DbColumn("FECHA_FIN")]
        public DateTime EndDate { get; set; }

        [DbColumn("ESTADO")]
        public string State { get; set; }

        public Advertisement()
        {
            State = "Active";
        }
    }
}
