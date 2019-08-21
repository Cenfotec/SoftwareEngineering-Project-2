using DataAccess.Mapper;

namespace DataAccess.Crud
{
    public class PaymentTransactionCrud : CrudFactory
    {
        public PaymentTransactionCrud() : base(entityObjectMapper: new PaymentTransactionObjectMapper(), entityMapperGeneric: new PaymentTransactionMapper()) { }
    }
}