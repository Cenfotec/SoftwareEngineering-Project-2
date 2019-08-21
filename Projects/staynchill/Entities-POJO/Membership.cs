using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Membership : BaseEntity
    {
        [PrimaryKey]
        public int Id { get; set; }

        [DbColumn("FK_HOTEL")]
        public int FkHotel { get; set; }

        [DbColumn("PRECIO")]
        public decimal Price { get; set; }

        [DbColumn("CANT_MESES")]
        public int NumberMonths { get; set; }

        [DbColumn("FECHA_CREACION")]
        public DateTime StartDate { get; set; }

        [DbColumn("FECHA_FIN")]
        public DateTime EndDate { get; set; }

        [DbColumn("ESTADO")]
        public string State { get; set; }

        public Membership(int numMonths)
        {
            StartDate = DateTime.UtcNow;
            NumberMonths = numMonths;
            EndDate = DateTime.UtcNow.AddMonths(NumberMonths);

        }

        public Membership(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 4)
            {
                FkHotel = Convert.ToInt32(infoArray[0]);
                Price = Convert.ToInt32(infoArray[1]);
                NumberMonths = Convert.ToInt32(infoArray[2]);
                StartDate = Convert.ToDateTime(infoArray[3]);
                EndDate = Convert.ToDateTime(infoArray[4]);
                State = "available";
            }
            else
            {
                throw new Exception("all values are require[fkhotel,price,numbermonths,startdate,enddate]");
            }

        }

        public Membership()
        {
        }
    }
}
