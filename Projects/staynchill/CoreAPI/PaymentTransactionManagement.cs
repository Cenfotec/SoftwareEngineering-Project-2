using DataAccess.Crud;
using Entities_POJO;
using System.Collections.Generic;

namespace Core {
    public class PaymentTransactionManagement {

        private PaymentTransactionCrud paymentTransactionCrud;

        public PaymentTransactionManagement() => paymentTransactionCrud = new PaymentTransactionCrud();

        public void Create(PaymentTransaction paymentTransaction) {
            paymentTransaction.Description = $"Monto total: {paymentTransaction.TotalAmount.ToString()}, fecha: {paymentTransaction.TransactionDate.ToString()}";
            paymentTransactionCrud.Create(paymentTransaction);
        }

        public List<PaymentTransaction> RetrieveAll() => paymentTransactionCrud.RetrieveAll<PaymentTransaction>();

        public PaymentTransaction RetrieveById(PaymentTransaction paymentTransaction) => paymentTransactionCrud.Retrieve<PaymentTransaction>(paymentTransaction);

        public void Update(PaymentTransaction paymentTransaction) => paymentTransactionCrud.Update(paymentTransaction);

        public void Delete(PaymentTransaction paymentTransaction) => paymentTransactionCrud.Delete(paymentTransaction);
    }
}
