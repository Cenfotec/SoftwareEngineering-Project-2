using System;
using PayPalCheckoutSdk.Core;
using BraintreeHttp;

using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using PayPalCheckoutSdk.Orders;
using PayPalCheckoutSdk.Payments;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Configuration;

namespace WebAPI.PayPal {
    /// <summary>
    /// configure your environment with your application credentials.
    /// </summary>
    public class PayPalClient {

        /// <summary>
        /// Set up PayPal environment with sandbox credentials.
        /// In production, use LiveEnvironment.
        /// </summary>
        /// <returns>SandboxEnvironment</returns>
        public static PayPalEnvironment Environment() {
            return new SandboxEnvironment(
                clientId: ConfigurationManager.AppSettings["clientId"],
            clientSecret: ConfigurationManager.AppSettings["clientSecret"]
            );
        }

        /// <summary>
        /// Returns PayPalHttpClient instance to invoke PayPal APIs.
        /// </summary>
        /// <returns>PayPalHttpClient</returns>
        public static HttpClient Client() {
            return new PayPalHttpClient(Environment());
        }

        /// <summary>
        /// Set up PayPal environment with sandbox credentials.
        /// In production, use LiveEnvironment.
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns>PayPalHttpClient</returns>
        public static HttpClient Client(string refreshToken) {
            return new PayPalHttpClient(Environment(), refreshToken);
        }

        /// <summary>
        /// Use this method to serialize Object to a JSON string.
        /// </summary>
        /// <param name="serializableObject"></param>
        /// <returns>String serialized Object</returns>
        public static String ObjectToJSONString(Object serializableObject) {
            MemoryStream memoryStream = new MemoryStream();

            var writer = JsonReaderWriterFactory.CreateJsonWriter(
                memoryStream,
                Encoding.UTF8,
                true,
                true,
                "  "
            );

            DataContractJsonSerializer ser = new DataContractJsonSerializer(serializableObject.GetType(), new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
            ser.WriteObject(writer, serializableObject);
            memoryStream.Position = 0;
            StreamReader sr = new StreamReader(memoryStream);
            return sr.ReadToEnd();
        }

        public static OrderRequest BuildRequestBody(string p_payee, string p_price)
        {
            OrderRequest orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = "CAPTURE",
                ApplicationContext = new ApplicationContext
                {

                },
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest {
                        AmountWithBreakdown = new AmountWithBreakdown
                        {
                                CurrencyCode = "USD",
                                Value = p_price
                        },
                        Payee = new Payee
                        {
                            Email = p_payee
                        }
                    }
                }
            };

            return orderRequest;
        }
        public static OrderRequest BuildRequestBody_CAPTUREV2(string p_payee, string p_price)
        {

         
            OrderRequest orderRequest = new OrderRequest()
            {

                CheckoutPaymentIntent = "CAPTURE",
                ApplicationContext = new ApplicationContext
                {

                },
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest {
                        AmountWithBreakdown = new AmountWithBreakdown
                        {
                                CurrencyCode = "USD",
                                Value = p_price
                        },
                        Payee = new Payee
                        {
                            Email = p_payee
                        }
                    }
                },
                Payer = new Payer
                {
                    Email = "emiliogarrorangelxboxone-facilitator@hotmail.com",
                    PayerId = "DCCKH3LCFALDL"
                }
            };

            return orderRequest;
        }
        public static OrderRequest BuildRequestBody_AUTHORIZEV2(string p_payee, string p_price)
        {

            OrderRequest orderRequest = new OrderRequest()
            {

                CheckoutPaymentIntent = "AUTHORIZE",
                ApplicationContext = new ApplicationContext
                {

                },
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest {
                        AmountWithBreakdown = new AmountWithBreakdown
                        {
                                CurrencyCode = "USD",
                                Value = p_price
                        },
                        Payee = new Payee
                        {
                            Email = p_payee
                        }
                    }
                },
                Payer = new Payer
                {
                    Email = "emiliogarrorangelxboxone-facilitator@hotmail.com",
                    PayerId = "DCCKH3LCFALDL"
                }
            };

            return orderRequest;
        }
        public async static Task<HttpResponse> CreateOrderCapture(string p_payee, string p_price, bool debug = false)
        {
            var request = new OrdersCreateRequest();
            request.Headers.Add("prefer", "return=representation");
            request.RequestBody(BuildRequestBody_CAPTUREV2(p_payee, p_price));
            var response = await PayPalClient.Client().Execute(request);

            if (debug)
            {
                //var result = response.Result<Order>();
                //Console.WriteLine("Status: {0}", result.Status);
                //Console.WriteLine("Order Id: {0}", result.Id);
                //Console.WriteLine("Intent: {0}", result.CheckoutPaymentIntent);
                //Console.WriteLine("Links:");
                //foreach (LinkDescription link in result.Links)
                //{
                //    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
                //}
                //AmountWithBreakdown amount = result.PurchaseUnits[0].AmountWithBreakdown;
                //Console.WriteLine("Total Amount: {0} {1}", amount.CurrencyCode, amount.Value);
                //Console.WriteLine("Response JSON: \n {0}", PayPalClient.ObjectToJSONString(result));
            }

            return response;
        }

        public async static Task<HttpResponse> CreateOrderAuthorize(string p_payee, string p_price, bool debug = false)
        {
            var request = new OrdersCreateRequest();
            request.Headers.Add("prefer", "return=representation");
            request.RequestBody(BuildRequestBody_AUTHORIZEV2(p_payee, p_price));
            var response = await PayPalClient.Client().Execute(request);

            if (debug)
            {
                //var result = response.Result<Order>();
                //Console.WriteLine("Status: {0}", result.Status);
                //Console.WriteLine("Order Id: {0}", result.Id);
                //Console.WriteLine("Intent: {0}", result.CheckoutPaymentIntent);
                //Console.WriteLine("Links:");
                //foreach (LinkDescription link in result.Links)
                //{
                //    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
                //}
                //AmountWithBreakdown amount = result.PurchaseUnits[0].AmountWithBreakdown;
                //Console.WriteLine("Total Amount: {0} {1}", amount.CurrencyCode, amount.Value);
                //Console.WriteLine("Response JSON: \n {0}", PayPalClient.ObjectToJSONString(result));
            }

            return response;
        }


        public async static Task<HttpResponse> CaptureOrder(string OrderId, bool debug = false)
        {
            var request = new OrdersCaptureRequest(OrderId);
            request.Prefer("return=representation");
            request.RequestBody(new OrderActionRequest());
            var response = await Client().Execute(request);

            if (debug)
            {
                //var result = response.Result<Order>();
                //Console.WriteLine("Status: {0}", result.Status);
                //Console.WriteLine("Order Id: {0}", result.Id);
                //Console.WriteLine("Intent: {0}", result.CheckoutPaymentIntent);
                //Console.WriteLine("Links:");
                //foreach (PayPalCheckoutSdk.Orders.LinkDescription link in result.Links)
                //{
                //    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
                //}
                //Console.WriteLine("Capture Ids: ");
                //foreach (PurchaseUnit purchaseUnit in result.PurchaseUnits)
                //{
                //    foreach (PayPalCheckoutSdk.Orders.Capture capture in purchaseUnit.Payments.Captures)
                //    {
                //        Console.WriteLine("\t {0}", capture.Id);
                //    }
                //}
                //AmountWithBreakdown amount = result.PurchaseUnits[0].AmountWithBreakdown;
                //Console.WriteLine("Buyer:");
                //Console.WriteLine("\tEmail Address: {0}\n\tName: {1} {2}\n",
                //    result.Payer.Email,
                //    result.Payer.Name.GivenName,
                //    result.Payer.Name.Surname);
                //Console.WriteLine("Response JSON:\n{0}", PayPalClient.ObjectToJSONString(result));
            }

            return response;
        }

        public async static Task<HttpResponse> AuthorizeOrder(string OrderId, bool debug = false)
        {
            var request = new OrdersAuthorizeRequest(OrderId);
            request.Prefer("return=representation");
            request.RequestBody(new AuthorizeRequest());
            var response = await PayPalClient.Client().Execute(request);

            if (debug)
            {
                //var result = response.Result<Order>();
                //Console.WriteLine("Status: {0}", result.Status);
                //Console.WriteLine("Order Id: {0}", result.Id);
                //Console.WriteLine("Authorization Id: {0}", result.PurchaseUnits[0].Payments.Authorizations[0].Id);
                //Console.WriteLine("Intent: {0}", result.CheckoutPaymentIntent);
                //Console.WriteLine("Links:");
                //foreach (PayPalCheckoutSdk.Orders.LinkDescription link in result.Links)
                //{
                //    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
                //}
                //AmountWithBreakdown amount = result.PurchaseUnits[0].AmountWithBreakdown;
                //Console.WriteLine("Buyer:");
                //Console.WriteLine("\tEmail Address: {0}", result.Payer.Email);
                //Console.WriteLine("Response JSON: \n {0}", PayPalClient.ObjectToJSONString(result));
            }

            return response;
        }
    }
}