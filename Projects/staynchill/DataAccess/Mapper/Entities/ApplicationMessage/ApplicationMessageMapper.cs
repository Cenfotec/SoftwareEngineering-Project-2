using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ApplicationMessageMapper : EntityMapperGeneric
    {
        public ApplicationMessageMapper() : base(dB_PR_BASE_NAME: "MESSAGE") { }
    }
}
