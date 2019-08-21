using DataAccess.Dao;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper {
    public class MembershipMapper : EntityMapperGeneric {
        public MembershipMapper(): base(dB_PR_BASE_NAME: "MEMBRESIA") {}
    }
}
