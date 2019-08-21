using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess.Mapper
{
    public class SMSMapper : EntityMapperGeneric
    {
        public SMSMapper() : base(dB_PR_BASE_NAME: "SMS") { }
    }
}