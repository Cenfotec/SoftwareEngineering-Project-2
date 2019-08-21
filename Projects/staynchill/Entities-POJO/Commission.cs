using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Commission : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("ID")]
        public int Id { get; set; }
        [DbColumn("FK_HOTEL")]
        public int FkHotel { get; set; }
        [DbColumn("PORCENTAJE")]
        public string Percentage { get; set; }

        public Commission()
        {

        }

        public Commission(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 1)
            {
                Id = Int32.Parse(infoArray[0]);
                FkHotel = Int32.Parse(infoArray[1]);
                Percentage = infoArray[2];
            }
            else
            {
                throw new Exception("All values are require[code,name,description,ArrivalDate, taxes]");
            }

        }
    }
}
