using System.Collections.Generic;
using DataAccess.Crud;
using Entities_POJO;
namespace Core
{
    public class SMSManagement
    {
        private SMSCrud smsCrud;

        public SMSManagement() => smsCrud = new SMSCrud();

        public void Create(SMS sms) => smsCrud.Create(sms);

        public List<SMS> RetrieveAll() => smsCrud.RetrieveAll<SMS>();

        public SMS RetrieveById(SMS sms) => smsCrud.Retrieve<SMS>(sms);

        public void Update(SMS sms) => smsCrud.Update(sms);

        public void Delete(SMS sms) => smsCrud.Delete(sms);
    }
}