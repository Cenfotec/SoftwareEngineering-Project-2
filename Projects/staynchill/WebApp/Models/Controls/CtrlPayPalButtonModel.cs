using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlPayPalButtonModel : CtrlBaseModel
    {
        public string DivId { get; set; }
        public string ClientId { get; set; }
        public string AmountValue { get; set; }
        public string TransactionCompletedByMessage { get; set; }
        public string Currency { get; set; }

        public CtrlPayPalButtonModel() {
            ViewName = "";
        }

        public CtrlPayPalButtonModel(
            string amountValue,
            string divId = "paypal-button-container",
            string transactionCompletedByMessage = "Transaction completed by ",
            string currency = "USD"
        ) {
            DivId = divId ?? throw new ArgumentNullException(nameof(divId));
            ClientId = "AZspv3QaiTNRMrvWUaucRG3l6gog_Jyue9byrNQrQO_cKf7Qv0d-Dhm4Xi1cOFIjvivWtu44rzaOkOqO";
            AmountValue = amountValue ?? throw new ArgumentNullException(nameof(amountValue));
            TransactionCompletedByMessage = transactionCompletedByMessage ?? throw new ArgumentNullException(nameof(transactionCompletedByMessage));
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }
    }
}