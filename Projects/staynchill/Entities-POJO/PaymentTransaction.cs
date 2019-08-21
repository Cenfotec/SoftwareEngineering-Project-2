using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class PaymentTransaction : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("ID")]
        public int Id { get; set; }

        [DbColumn("FK_FORMA_PAGO")]
        public int FkFormaPago { get; set; }

        [DbColumn("FK_HOTEL")]
        public int FkHotel { get; set; }

        [DbColumn("FECHA")]
        public DateTime TransactionDate { get; set; }

        [DbColumn("MONTO")]
        public decimal TotalAmount { get; set; }

        [DbColumn("DESCRIPCION")]
        public string Description { get; set; }

        [DbColumn("CATEGORIA")]
        public string Category { get; set; }

        [DbColumn("ORDER_ID")]
        public string OrderId { get; set; }

        [DbColumn("PAYER_ID")]
        public string PayerId { get; set; }

        [DbColumn("COMISION_PORCENTAJE")]
        public decimal CommissionPercentage { get; set; }

        [DbColumn("COMISION_TOTAL")]
        public decimal CommissionTotal { get; set; }

        [DbColumn("PRECIO_BASE")]
        public decimal BasePrice { get; set; }

        [DbColumn("PAYPAL_EMAIL")]
        public string PaypalEmail { get; set; }


        public PaymentTransaction()
        {
        }
    }

    public class PaymentTransactionV2
    {
        public int Id { get; set; }
        public int FkFormaPago { get; set; }
        public int FkHotel { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string OrderId { get; set; }
        public string PayerId { get; set; }
        public decimal CommissionPercentage { get; set; } = 0.0M;
        public decimal CommissionTotal { get; set; } = 0.0M;
        public decimal BasePrice { get; set; } = 0.0M;
        public string PaypalEmail { get; set; } = "";


        public PaymentTransactionV2()
        {
        }

        public PaymentTransaction getV1()
        {
            const string dateFormat = "yyyy-MM-dd HH:mm:ss.fff";
            return new PaymentTransaction()
            {
                Id = 0,
                FkFormaPago = 0,
                FkHotel = FkHotel,
                TransactionDate = DateTime.ParseExact(DateTime.Now.ToString(dateFormat), dateFormat, CultureInfo.InvariantCulture),
                Description = Description,
                Category = Category ?? "",
                OrderId = OrderId,
                PayerId = PayerId,
                CommissionPercentage = CommissionPercentage,
                CommissionTotal = CommissionTotal,
                BasePrice = BasePrice,
                PaypalEmail = PaypalEmail ?? ""
            };
        }
    }
}
