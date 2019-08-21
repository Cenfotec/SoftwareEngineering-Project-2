using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class HotelFiltro : BaseEntity
    {
        [DbColumn("HOTEL_NOMBRE")]
        public string HotelNombre { get; set; }
        [DbColumn("TIPO_HABITACION_PERSONAS")]
        public int TipoHabitacionPersonas { get; set; }
        [DbColumn("FECHA_INICIO")]
        public DateTime FechaInicio { get; set; }
        [DbColumn("FECHA_FIN")]
        public DateTime FechaFin { get; set; }

        public HotelFiltro()
        {

        }
    }
}