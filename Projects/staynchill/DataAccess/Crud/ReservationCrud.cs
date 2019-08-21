using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class ReservationCrud : CrudFactory
    {
        public ReservationCrud() : base(entityObjectMapper: new ReservationObjectMapper(), entityMapperGeneric: new ReservationMapper()) { }

        ReservationMapper reservationMapper = new ReservationMapper();

        public T CreateReservationReturn<T>(Reservation reservation)
        {

            try
            {

                var instance = SqlDao.GetInstance();
                var operation = reservationMapper.GetCreateReservationReturn(reservation);
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

        public T CreateSubreservation<T>(Reservation reservation, User user)
        {

            try
            {

                var instance = SqlDao.GetInstance();
                var operation = reservationMapper.GetCreateSubreservation(reservation, user);
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

        public List<Reservation> RetrieveAllById(int usuario)
        {
            try
            {

                var instance = SqlDao.GetInstance();
                var operation = reservationMapper.GetRetAllByIdStatement(usuario);
                var lstResult = instance.ExecuteQueryProcedure(operation);

                if (lstResult.Count <= 0) return default(List<Reservation>);

                var objs = EntityObjectMapper.BuildObjects(lstResult);

                return objs.Cast<Reservation>().ToList();

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;

        }

        public async Task SendInvoice(ReservationInvoice reservationInvoice)
        {
            var correo = reservationInvoice.CorreoUsuario;

            var client = new SendGridClient("sendgrid_key");
            var from = new EmailAddress("reservacion@staynchill.com", "Stay n'Chill");
            var subject = "Factura de Reservación";
            var to = new EmailAddress(correo);
            var plainTextContent = "";

            var htmlContent = string.Format(@"<div style='max-width: 800px; margin: auto; padding: 30px; border: 1px solid #eee; box-shadow: 0 0 10px rgba(0, 0, 0, .15); font-size: 16px; line-height: 24px; font-family: 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif; color: #555; border-radius: 7px;'>
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
                    Hotel
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