using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Common : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("ACCION")]
        public string Action { get; set; }
        [DbColumn("TIPO")]
        public string Type { get; set; }
        [DbColumn("FECHA")]
        public string Date { get; set; }

        public Common()
        {
        }

        public Common(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 3)
            {
                Action = infoArray[0];
                Type = infoArray[1];
                Date = infoArray[2];
            }
            else
            {
                throw new Exception("All values are require[code,name,description,ArrivalDate, taxes]");
            }

        }
    }
}
