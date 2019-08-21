using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Code : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("CORREO")]
        public string Correo { get; set; }
        [DbColumn("NOMBRE")]
        public string Nombre { get; set; }
        [DbColumn("CODE")]
        public string Value { get; set; }

        public Code()
        {

        }

        public Code(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 3)
            {
                Correo = infoArray[0];
                Nombre = infoArray[1];
                Value = infoArray[2];
            }
            else
            {
                throw new Exception("All values are require[code,name,description,ArrivalDate, taxes]");
            }

        }
    }
}
