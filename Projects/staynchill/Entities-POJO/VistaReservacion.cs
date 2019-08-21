using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class VistaReservacion : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("ID")]
        public int Id { get; set; }
        [DbColumn("USUARIO")]
        public string User { get; set; }
        [DbColumn("HOTEL")]
        public string Hotel { get; set; }
        [DbColumn("NUM_HABITACION")]
        public int RoomNum { get; set; }
        [DbColumn("FECHA_INCIO")]
        public DateTime BeginDate { get; set; }
        [DbColumn("FECHA_FIN")]
        public DateTime EndDate { get; set; }
        [DbColumn("PRECIO")]
        public decimal Price { get; set; }
        [DbColumn("ESTADO")]
        public string Status { get; set; }
        
        public VistaReservacion()
        {

        }

        public VistaReservacion(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 7)
            {
                Id = Int32.Parse(infoArray[0]);
                User = infoArray[1];
                Hotel = infoArray[2];
                RoomNum = Int32.Parse(infoArray[3]);
                BeginDate = DateTime.Parse(infoArray[4]);
                EndDate = DateTime.Parse(infoArray[5]);
                Price = Decimal.Parse(infoArray[3]);
                Status = infoArray[7];
            }
            else
            {
                throw new Exception("All values are require[code,name,description,ArrivalDate, taxes]");
            }

        }
    }
}
