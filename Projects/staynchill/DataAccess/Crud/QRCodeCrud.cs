using DataAccess.Dao;
using DataAccess.Mapper;
using DataAccess.Mapper.Entities.QRCode;
using Entities_POJO;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class QRCodeCrud : CrudFactory
    {
       public QRCodeCrud() : base(entityObjectMapper: new QRCodeObjectMapper(),
           entityMapperGeneric: new QRCodeMapper()) { }

        QRCodeMapper qrCodeMapper = new QRCodeMapper();

        public async Task SendEmail(User user, string qrCodeValue)
        {
            var correo = user.Correo;

            var client = new SendGridClient("sendgrid_key");
            var from = new EmailAddress("reservacion@staynchill.com", "Stay n'Chill");
            var subject = "Código QR de Reservación";
            var to = new EmailAddress(correo);
            var plainTextContent = "";

            var htmlContent = string.Format(@"
                <div style='text-align:center;'>
                    <div style='border-radius:20px 20px 0 0;display:inline-block;'>
                        <div style='letter-spacing:1px;font-family: monospace,sans-serif;border-radius:12px 12px 0 0;background-color: #5D78FF;'>
                            <p style='color:#FFF;font-size:1.5rem;padding:2rem 2rem 0 2rem;margin: 0;'>Código QR de Reservación</p>
                            <p style='color:#F2F2F2;font-size:1rem;padding:0 2rem 2rem 2rem;margin:0;'>Stay n'Chill</p>
                        </div>
                        <div style='border-right: 1px dashed #BEBEBE;border-bottom: 1px dashed #BEBEBE;border-left: 1px dashed #BEBEBE;'>
                            <img src='https://res.cloudinary.com/qubitscenfo/image/upload/v1564822446/" + $@"{qrCodeValue}" + @"' style='padding:2.5rem'>
                        </div>
                    </div>
                </div>");

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public T RetrieveByReservationId<T>(int idReservation)
        {

            try
            {

                var instance = SqlDao.GetInstance();
                var operation = qrCodeMapper.GetRetrieveByReservationIdStatement(idReservation);
                var lstResult = instance.ExecuteQueryProcedure(operation);

                if (lstResult.Count <= 0) return default(T);

                var objs = EntityObjectMapper.BuildObjects(lstResult);

                return objs.Cast<T>().ToList()[0];

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return default(T);
        }

        public List<QRCode> RetrieveAllByReservationId(int idReservation)
        {

            try
            {
                var qrCodeMapper = new QRCodeMapper();
                var instance = SqlDao.GetInstance();
                var operation = qrCodeMapper.GetRetrieveAllByReservationIdStatement(idReservation);
                var lstResult = instance.ExecuteQueryProcedure(operation);

                if (lstResult.Count <= 0) return default(List<QRCode>);

                var objs = EntityObjectMapper.BuildObjects(lstResult);

                return objs.Cast<QRCode>().ToList();

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }

        public async Task SendEmailWithFactura(User user, string qrCodeValue, ReservationInvoice reservationInvoice)
        {
            var correo = user.Correo;

            var client = new SendGridClient("sendgrid_key");
            var from = new EmailAddress("reservacion@staynchill.com", "Stay n'Chill");
            var subject = "Código QR de Reservación";
            var to = new EmailAddress(correo);
            var plainTextContent = "";

            var htmlContent = string.Format(@"
                <div style='text-align:center;'>
                    <div style='border-radius:20px 20px 0 0;display:inline-block;'>
                        <div style='letter-spacing:1px;font-family: monospace,sans-serif;border-radius:12px 12px 0 0;background-color: #5D78FF;'>
                            <p style='color:#FFF;font-size:1.5rem;padding:2rem 2rem 0 2rem;margin: 0;'>Código QR de Reservación</p>
                            <p style='color:#F2F2F2;font-size:1rem;padding:0 2rem 2rem 2rem;margin:0;'>Stay n'Chill</p>
                        </div>
                        <div style='border-right: 1px dashed #BEBEBE;border-bottom: 1px dashed #BEBEBE;border-left: 1px dashed #BEBEBE;'>
                            <img src='https://res.cloudinary.com/qubitscenfo/image/upload/v1564822446/" + $@"{qrCodeValue}" + @"' style='padding:2.5rem'>
                        </div>
                    </div>
                </div>










<div style='margin-top:5rem; max-width: 800px; margin: auto; padding: 30px; border: 1px solid #eee; box-shadow: 0 0 10px rgba(0, 0, 0, .15); font-size: 16px; line-height: 24px; font-family: 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif; color: #555; border-radius: 7px;'>
        <table cellpadding='0' cellspacing='0' style='width: 100%; line-height: inherit; text-align: left;'>
            <tr style='font-size: 45px;
            line-height: 45px;
            color: #333;padding-bottom: 40px;'>
                <td colspan='2' style='padding: 5px; vertical-align: top;'>
                    <table style='width: 100%; line-height: inherit; text-align: left;'>
                        <tr>
                            <td  style='font-size: 45px;
                            line-height: 45px;
                            color: #333;padding: 5px; vertical-align: top;'>
                                <img src='https://res.cloudinary.com/qubitscenfo/image/upload/v1565417512/ckxg43ppvqlizl1mzzie.png' style='width:100%; max-width:300px;'>
                            </td>
                            
                            
                        </tr>
                    </table>
                </td>
            </tr>
            
            <tr class='information'>
                <td colspan='2' style='padding: 5px; vertical-align: top;'>
                    <table>
                        
                    </table>
                </td>
            </tr>
            
            <tr class='heading'>
                <td style='padding: 5px; vertical-align: top;'>
                    Método de Pago
                </td>
                
                <td style='padding: 5px; vertical-align: top;'>
                    PayPal
                </td>
            </tr>
            
            
            
            <tr class='heading'>
                <td style='padding: 5px; vertical-align: top;'>
                    Item
                </td>
                
                <td style='padding: 5px; vertical-align: top;'>
                    Precio
                </td>
            </tr>
            
            <tr class='item'>
                <td style='padding: 5px; vertical-align: top;'>
                    Reservación
                </td>
                
                <td style='padding: 5px; vertical-align: top;'>
                    " + $@"{reservationInvoice.NombreHotel}" + @"
                </td>
            </tr>
            
            <tr class='total'>
                <td>
                    
                </td>
                <td>
                   Total: " + $@"{reservationInvoice.PrecioTotal}" + @"
                </td>
            </tr>
        </table>
    </div>");

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}