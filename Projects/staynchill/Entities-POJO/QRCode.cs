using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class QRCode : BaseEntity
    {
        [DbColumn("ID")]
        public int Id { get; set; }
        [DbColumn("VALOR")]
        public string Value { get; set; }
        [DbColumn("ESTADO")]
        public string State { get; set; }
        [DbColumn("FK_SUB_RESERVACION")]
        public int FK_SubReservation { get; set; }

        public QRCode()
        {

        }
    }
}
