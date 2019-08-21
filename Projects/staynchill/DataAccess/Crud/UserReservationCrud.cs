using DataAccess.Mapper;
using DataAccess.Mapper.Entities.UserReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class UserReservationCrud : CrudFactory
    {
        public UserReservationCrud() : base(entityObjectMapper: new UserReservationObjectMapper(),
            entityMapperGeneric: new UserReservationMapper()) { }
    }
}
