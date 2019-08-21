using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Room : BaseEntity
    {
        [DbColumn("ID")]
        public int Id { get; set; }
        [DbColumn("FK_TIPO_HABITACION")]
        public int RoomType { get; set; }
        [DbColumn("FK_NOMBRE_TIPO_HABITACION")]
        public string RoomTypeName { get; set; }
        [PrimaryKey]
        [DbColumn("NUM_HABITACION")]
        public int RoomNumber { get; set; }
        [DbColumn("DESCRIPCION")]
        public string Description { get; set; }
        [DbColumn("ESTADO")]
        public string State { get; set; }
        [DbColumn("HOTEL")]
        public int IdHotel { get; set; }
        [DbColumn("Valor")]
        public string Value { get; set; }
        [DbColumn("Tipo")]
        public string Type { get; set; }


        public Room() { }

        public Room(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >=5)
            {
                Id = Int32.Parse(infoArray[0]);
                RoomType = Int32.Parse(infoArray[1]);
                RoomNumber = Int32.Parse(infoArray[2]);
                Description = infoArray[3];
                State = infoArray[4];
                IdHotel = Int32.Parse(infoArray[5]);
            }
            else
            {
                throw new Exception("all values are required");
            }
        }

    }
}
