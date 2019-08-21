using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Ubication : BaseEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        [DbColumn("FK_HOTEL")]
        public int Hotel { get; set; }
        [DbColumn("LATITUD")]
        public string Latitude { get; set; }
        [DbColumn("LONGITUD")]
        public string Longitude { get; set; }
        [DbColumn("PROVINCIA")]
        public int Province { get; set; }
        [DbColumn("CANTON")]
        public int Canton { get; set; }
        [DbColumn("DISTRITO")]
        public int District { get; set; }

        public Ubication()
        {

        }

        public Ubication(string [] infoArray)
        {
            if(infoArray != null && infoArray.Length >= 7)
            {
                Latitude = infoArray[2];
                Longitude = infoArray[3];
                var province = 0;
                if (Int32.TryParse(infoArray[4], out province))
                    Province = province;
                else
                    throw new Exception("La provincia debe ser un número");
                var canton = 0;
                if (Int32.TryParse(infoArray[5], out canton))
                    Canton = canton;
                else
                    throw new Exception("El cantón debe ser un número");
                var district = 0;
                if (Int32.TryParse(infoArray[6], out district))
                    District = district;
                else
                    throw new Exception("El distrito debe ser un número");
            }else
            {
                throw new Exception("Todos los valores son requeridos [Latitud, longitud, provincia, canton y distrito]");
            }
        }
    }
}