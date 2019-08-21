using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class AvailableRooms : BaseEntity
    {
        [DbColumn("ID")]
        public int Id { get; set; }
        [DbColumn("FK_TIPO_HABITACION")]
        public int RoomType { get; set; }
        [DbColumn("NUM_HABITACION")]
        public int RoomNumber { get; set; }
        [DbColumn("DESCRIPCION")]
        public string Description { get; set; }
        [DbColumn("VALOR")]
        public string Value { get; set; }
        [DbColumn("NOMBRE")]
        public string Nombre { get; set; }
        [DbColumn("DESCRIPCION_TH")]
        public string DescripcionTH { get; set; }
        [DbColumn("CANT_PERSONAS")]
        public int CantPersonas { get; set; }
        [DbColumn("CANT_CAMAS")]
        public int CantCamas { get; set; }
        [DbColumn("PERMITE_MASCOTAS")]
        public string PermiteMascotas { get; set; }
        [DbColumn("PRECIO")]
        public decimal Precio { get; set; }
        [DbColumn("HOTEL")]
        public int IdHotel { get; set; }
        [DbColumn("HORARIO_CHECK_IN")]
        public DateTime HorarioCheckIn { get; set; }
        [DbColumn("HORARIO_CHECK_OUT")]
        public DateTime HorarioCheckOut { get; set; }

        public AvailableRooms() { }

        public AvailableRooms(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 7)
            {
                Id = Int32.Parse(infoArray[0]);
                RoomType = Int32.Parse(infoArray[1]);
                RoomNumber = Int32.Parse(infoArray[2]);
                Description = infoArray[3];
                Value = infoArray[4];
                Nombre = infoArray[5];
                DescripcionTH = infoArray[6];
                CantPersonas = Int32.Parse(infoArray[7]);
                CantCamas = Int32.Parse(infoArray[8]);
                PermiteMascotas = infoArray[9];
                Precio = Decimal.Parse(infoArray[10]);
                IdHotel = Int32.Parse(infoArray[11]);
                HorarioCheckIn = DateTime.Parse(infoArray[12]);
                HorarioCheckOut = DateTime.Parse(infoArray[13]);
            }
            else
            {
                throw new Exception("all values are required");
            }
        }

    }
}
