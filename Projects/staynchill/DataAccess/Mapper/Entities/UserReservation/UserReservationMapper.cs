using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Entities.UserReservation
{
    public class UserReservationMapper : EntityMapperGeneric
    {
        public UserReservationMapper() : base(dB_PR_BASE_NAME: "USERRESERVATION") { }
    }
}
