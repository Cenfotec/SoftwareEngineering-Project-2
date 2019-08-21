using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class RoomType : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("ID")]
        public int Id { get; set; }

        [DbColumn("NOMBRE")]
        public string Name { get; set; }

        [DbColumn("DESCRIPCION")]
        public string Description { get; set; }

        [DbColumn("CANT_PERSONAS")]
        public int AmountPeople { get; set; }

        [DbColumn("CANT_CAMAS")]
        public int AmountBeds { get; set; }

        [DbColumn("PERMITE_MASCOTAS")]
        public string PetsAllowed { get; set; }

        [DbColumn("PRECIO")]
        public decimal Price { get; set; }

        [DbColumn("FK_HOTEL")]
        public int IdHotel { get; set; }

        [DbColumn("ESTADO")]
        public string State { get; set; }

        [DbColumn("HORARIO_CHECK_IN")]
        public DateTime HorarioCheckIn { get; set; }

        [DbColumn("HORARIO_CHECK_OUT")]
        public DateTime HorarioCheckOut { get; set; }

        public RoomType() { }

        public RoomType(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 8)
            {
                Id = Int32.Parse(infoArray[0]);
                Name = infoArray[1];
                Description = infoArray[2];
                AmountPeople = Int32.Parse(infoArray[3]);
                AmountBeds = Int32.Parse(infoArray[4]);
                PetsAllowed = infoArray[5];
                Price = decimal.Parse(infoArray[6]);
                State = infoArray[7];
                //IdHotel = infoArray[8];
                //Picture = infoArray[9];
            }
            else
            {
                throw new Exception("All values are require[Id,name,description,cantidad de personas, cantidad de camas, mascotas permitidas, precio, estado]");
            }

        }
    }
}