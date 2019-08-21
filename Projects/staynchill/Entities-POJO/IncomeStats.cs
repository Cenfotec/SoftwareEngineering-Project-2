using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class CantVentasByDayStats : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("DAY_OF_MONTH")]
        public int DayOfMonth { get; set; }

        [DbColumn("CANT_VENTAS")]
        public int CantVentas { get; set; }
    }
}
