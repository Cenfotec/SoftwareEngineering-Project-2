using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class PaymentTransactionObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_FK_FORMA_PAGO = "FK_FORMA_PAGO";
        private const string DB_COL_FK_HOTEL = "FK_HOTEL";
        private const string DB_COL_MONTO = "MONTO";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_DESCRIPCION = "DESCRIPCION";
        private const string DB_COL_CATEGORIA = "CATEGORIA";
        private const string DB_COL_ORDER_ID = "ORDER_ID";
        private const string DB_COL_PAYER_ID = "PAYER_ID";
        private const string DB_COL_COMISION_PORCENTAJE = "COMISION_PORCENTAJE";
        private const string DB_COL_COMISION_TOTAL = "COMISION_TOTAL";
        private const string DB_COL_PRECIO_BASE = "PRECIO_BASE";
        private const string DB_COL_PAYPAL_EMAIL = "PAYPAL_EMAIL";

        public override BaseEntity BuildObject(Dictionary<string, object> row) => new PaymentTransaction
        {
            Id = GetIntValue(row, DB_COL_ID),
            FkFormaPago = GetIntValue(row, DB_COL_FK_FORMA_PAGO),
            FkHotel = GetIntValue(row, DB_COL_FK_HOTEL),
            Description = GetStringValue(row, DB_COL_DESCRIPCION),
            Category = GetStringValue(row, DB_COL_CATEGORIA),
            TransactionDate = GetDateValue(row, DB_COL_FECHA),
            TotalAmount = GetDecimalValue(row, DB_COL_MONTO),
            CommissionPercentage = GetDecimalValue(row, DB_COL_COMISION_PORCENTAJE),
            CommissionTotal = GetDecimalValue(row, DB_COL_COMISION_TOTAL),
            BasePrice = GetDecimalValue(row, DB_COL_PRECIO_BASE),
            OrderId = GetStringValue(row, DB_COL_ORDER_ID),
            PayerId = GetStringValue(row, DB_COL_PAYER_ID),
            PaypalEmail = GetStringValue(row, DB_COL_PAYPAL_EMAIL)
        };

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var paymentTransaction = BuildObject(row);
                lstResults.Add(item: paymentTransaction);
            }

            return lstResults;
        }
    }
}