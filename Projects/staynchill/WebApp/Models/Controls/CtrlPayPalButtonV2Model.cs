using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlPayPalButtonV2Model : CtrlBaseModel
    {
        public string DivId { get; set; }
        public string ClientId { get; set; }
        public string TransactionCompletedByMessage { get; set; }
        public string Currency { get; set; }

        public CtrlPayPalButtonV2Model() {
            ViewName = "";
        }

        public CtrlPayPalButtonV2Model(
            string divId = "paypal-button-container",
            string transactionCompletedByMessage = "Transaction completed by ",
            string currency = "USD"
        ) {
            DivId = divId ?? throw new ArgumentNullException(nameof(divId));
            ClientId = "AZspv3QaiTNRMrvWUaucRG3l6gog_Jyue9byrNQrQO_cKf7Qv0d-Dhm4Xi1cOFIjvivWtu44rzaOkOqO";
            TransactionCompletedByMessage = transactionCompletedByMessage ?? throw new ArgumentNullException(nameof(transactionCompletedByMessage));
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }
    }
}