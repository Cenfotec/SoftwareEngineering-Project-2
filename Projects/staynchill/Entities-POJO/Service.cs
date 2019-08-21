using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Service : BaseEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        [DbColumn("NOMBRE")]
        public string Name { get; set; }
        [DbColumn("FK_HOTEL")]
        public int Hotel { get; set; }
        [DbColumn("DESCRIPCION")]
        public string Description { get; set; }
        [DbColumn("CEDULA_JURIDICA")]
        public int LegalNumber { get; set; }
        [DbColumn("TIPO")]
        public string Type { get; set; }
        [DbColumn("HORARIO_APERTURA")]
        public DateTime OpeningSchedule { get; set; }
        [DbColumn("HORARIO_CIERRE")]
        public DateTime ClosingSchedule { get; set; }
        [DbColumn("ESTADO")]
        public string State { get; set; }

        public Service()
        {

        }

        public Service(string [] infoArray)
        {
            if(infoArray != null && infoArray.Length >= 6)
            {
                Name = infoArray[0];
                Description = infoArray[1];
                Type = infoArray[3];
                var dateOpening = DateTime.Now;
                if (DateTime.TryParse(infoArray[4], out dateOpening))
                    OpeningSchedule = dateOpening;
                else
                    throw new Exception("El formato de horario de apertura no es correcto");
                var dateClosing = DateTime.Now;
                if (DateTime.TryParse(infoArray[5], out dateClosing))
                    ClosingSchedule = dateClosing;
                else
                    throw new Exception("El formato de horario de apertura no es correcto");
            }
        }
    }
}
