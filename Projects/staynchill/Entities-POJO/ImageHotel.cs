using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class ImageHotel : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("Valor")]
        public string Value { get; set; }
        [DbColumn("Tipo")]
        public string Type { get; set; }
        [DbColumn("FK_HOTEL")]
        public string Hotel { get; set; }

        public ImageHotel()
        {

        }

        public ImageHotel(string [] InfoArray)
        {
            if (InfoArray!= null && InfoArray.Length >= 3)
            {
                Value = InfoArray[0];
                Type = InfoArray[1];
                Hotel = InfoArray[2];
            } else
            {
                throw new Exception("Todos los valores son requeridos [Valor, tipo, hotel]");
            }
        }
    }
}
