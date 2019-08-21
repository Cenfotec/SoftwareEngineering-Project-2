using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class UserReservation : BaseEntity
    {
        [DbColumn("ID")]
        [PrimaryKey]
        public int Id { get; set; }
        [DbColumn("ID_SUBRESERVACION")]
        public int Subreservacion { get; set; }
        [DbColumn("ID_CARRITO")]
        public int Carrito { get; set; }
        [DbColumn("FK_HOTEL")]
        public int Hotel { get; set; }
        [DbColumn("QR_VALUE")]
        public string QRCode { get; set; }
        [DbColumn("QR_ESTADO")]
        public string QRState { get; set; }
        [DbColumn("ESTADO")]
        public string State { get; set; }

        public UserReservation()
        {

        }
    }
}
