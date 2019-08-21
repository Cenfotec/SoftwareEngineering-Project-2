using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;


namespace WebAPI.PayPal
{
    class TokenResponse
    {

        public string scope { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string app_id { get; set; }
        public int expires_in { get; set; }
        public string nonce { get; set; }
    }
    class PayPalAPI
    {
        public static HttpClient ApiCLient { get; set; }
        private static int Sender_batch_id_counter { get; set; } = 0;

        private static async Task<TokenResponse> GetToken()
        {
            var client = new WebClient();
            client.Headers.Add("authorization", "basic token");
            client.Headers.Add("content-type", "application/x-www-form-urlencoded");
            client.Headers.Add("accept-language", "en_US");
            client.Headers.Add("accept", "application/json");

            var body = "grant_type=client_credentials";

            var response = Task.Run(() => JsonConvert.DeserializeObject<TokenResponse>(client.UploadString("https://api.sandbox.paypal.com/v1/oauth2/token", "POST", body))).ConfigureAwait(false);
            return await response;
        }

        public static async Task<string> SendPaymentToHotel(string hotelPayPalEmail, string amount, string currency = "USD")
        {
            var client = new WebClient();
            client.Headers.Clear();
            var tokenResponse = await GetToken().ConfigureAwait(false);

            string token = $"Bearer {tokenResponse.access_token}";

            int randomBatch() => new Random().Next();

            var Sender_batch_id = $"Payouts_2019_{randomBatch()}_666";
            Sender_batch_id_counter++;

            var bodyV2 = new {
                sender_batch_header = new
                {
                    email_subject = "You have a payment",
                    sender_batch_id = Sender_batch_id
                },
                items = new object[]
                {
                    new
                    {
                        recipient_type = "EMAIL",
                        amount = new
                        {
                            value = amount,
                            currency = currency
                        },
                        receiver = hotelPayPalEmail,
                        note = "Pago de reservación",
                        sender_item_id = "item-1-" + Sender_batch_id
                    }
                }
            };

            var bodyString = JsonConvert.SerializeObject(bodyV2);

            const string WebApi_endpoint = "https://api.sandbox.paypal.com/";

            ApiCLient = new HttpClient
            {
                BaseAddress = new Uri(WebApi_endpoint)
            };

            ApiCLient.DefaultRequestHeaders.Accept.Clear();

            var acceptJson = new MediaTypeWithQualityHeaderValue("application/json");
            ApiCLient.DefaultRequestHeaders.Accept.Add(acceptJson);
            ApiCLient.DefaultRequestHeaders.Add("authorization", token);

            using (HttpResponseMessage responseV2 = await ApiCLient.PostAsJsonAsync("v1/payments/payouts", bodyV2).ConfigureAwait(false))
            {

                if (responseV2.IsSuccessStatusCode)
                {

                    var operationResult = await responseV2.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return operationResult;

                }
                else
                {
                    throw new Exception(responseV2.ReasonPhrase);
                }
            }
        }
    }
}