using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Rol : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("NOMBRE")]
        public string Name { get; set; }
        [DbColumn("FK_HOTEL")]
        public int Hotel { get; set; }
        [DbColumn("PERMISOS_STRING")]
        public string PermisosString { get; set; }

        public Rol()
        {

        }

        public Rol(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 2)
            {
                Name = infoArray[0];
                Hotel = Int32.Parse(infoArray[1]);
            }
            else
            {
                throw new Exception("All values are require[code,name,description,ArrivalDate, taxes]");
            }

        }
    }
}
