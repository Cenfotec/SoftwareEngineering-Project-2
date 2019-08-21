using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class SMS : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("ID")]
        public int Id { get; set; }

        [DbColumn("FK_HOTEL")]
        public int FkHotel { get; set; }

        [DbColumn("MENSAJE")]
        public string Message { get; set; }

        public SMS()
        {
        }
    }
}
