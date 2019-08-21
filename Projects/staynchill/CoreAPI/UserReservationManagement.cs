using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class UserReservationManagement
    {
        private UserReservationCrud crudUserReservation;

        public UserReservationManagement() => crudUserReservation = new UserReservationCrud();

        public UserReservation RetrieveById(UserReservation userReservation) => crudUserReservation.Retrieve<UserReservation>(userReservation);
    }
}
