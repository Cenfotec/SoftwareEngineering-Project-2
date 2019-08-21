using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities_POJO.InfoChatBot;

namespace CoreAPI
{
    public class CommissionManagement
    {
        private CommissionCrud commissionCrud;

        public CommissionManagement() => commissionCrud = new CommissionCrud();

        public void Create(Commission commission) => commissionCrud.Create(commission);

        public void Create(UsuarioChat commission) => commissionCrud.Create2(commission);


        public void Update(Commission commission) => commissionCrud.Update(commission);

        public async Task Email(EmailMembership email) => await commissionCrud.Email(email);

        public Commission IsAdminHotelRegistered(int fkHotel) => commissionCrud.IsAdminHotelRegistered(fkHotel);

        public List<Commission> getCommission(Commission cedulaJuridicaDeHotel) => commissionCrud.getCommission(cedulaJuridicaDeHotel);
    }
}
