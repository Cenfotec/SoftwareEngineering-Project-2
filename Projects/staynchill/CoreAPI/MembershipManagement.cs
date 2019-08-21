using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace Core
{
    public class MembershipManagement {

        private MembershipCrud membershipCrud;

        public MembershipManagement() => membershipCrud = new MembershipCrud();

        public void Create(Membership membership)
        {
            membership.StartDate = DateTime.UtcNow;
            membership.EndDate = DateTime.UtcNow.AddMonths(membership.NumberMonths);
            membershipCrud.Create(membership);
        }

        public List<Membership> RetrieveAll()
        {
            return membershipCrud.RetrieveAll<Membership>();
        }

        public Membership RetrieveById(Membership membership) => membershipCrud.Retrieve<Membership>(membership);

        public void Update(Membership membership) => membershipCrud.Update(membership);

        public void Delete(Membership membership) => membershipCrud.Delete(membership);
    }
}
