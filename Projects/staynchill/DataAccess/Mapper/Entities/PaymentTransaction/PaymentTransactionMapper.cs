using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Mapper
{
    public class PaymentTransactionMapper : EntityMapperGeneric
    {
        public PaymentTransactionMapper() : base(dB_PR_BASE_NAME: "TRANSACCIONES_PAGO") { }
    }
}