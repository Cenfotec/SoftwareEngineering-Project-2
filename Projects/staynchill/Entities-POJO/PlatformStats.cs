using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class PlatformStats : BaseEntity
    {
        [DbColumn("Total")]
        public decimal Total { get; set; }

        public PlatformStats()
        {

        }
    }
}
