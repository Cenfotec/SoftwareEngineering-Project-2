using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DataAccess.Crud
{
    public class HotelCrud : CrudFactory
    {
        public HotelCrud() : base(entityObjectMapper: new HotelObjectMapper(), entityMapperGeneric: new HotelMapper()) { }

        HotelMapper hotelMapper = new HotelMapper();

        public List<Hotel> RetrieveAllByUser(string user)
        {
            try
            {
                HotelMapper hotelMapper = new HotelMapper();
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        hotelMapper.GetRetriveAllByIdStatement(user)
                    );

                if (lstResult.Count <= 0) return default(List<Hotel>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Hotel>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }

        public bool AsociarHotelAdmin(int fkHotel, string correo)
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = hotelMapper.GetAsociarHotelAdminStatement(fkHotel, correo);
                instance.ExecuteProcedure(operation);

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return true;
        }

        public List<Hotel> RetrieveAllAdministrador()
        {

            try
            {
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        hotelMapper.GetRetriveAllAdministradorStatement()
                    );

                if (lstResult.Count <= 0) return default(List<Hotel>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Hotel>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }

        public CommissionHotel getCommission(int hotel)
        {

            try
            {
                var mapperComissionHotel = new CommissionHotelObjectMapper();
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        hotelMapper.GetCommissionStatement(hotel)
                    );

                if (lstResult.Count <= 0) return null;

                var obj = mapperComissionHotel.BuildObjects(lstResult);

                return obj.Cast<CommissionHotel>().ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }

        public List<Hotel> RetrieveAllByFiltro(HotelFiltro hotelFiltro)
        {

            try
            {
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        hotelMapper.GetRetrieveAllByFiltroStatement(hotelFiltro)
                    );

                if (lstResult.Count <= 0) return default(List<Hotel>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Hotel>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }

        public async Task SendMembershipEmail(CommissionHotel commissionHotel, User user, decimal totalPrice)
        {
            var correo = user.Correo;

            var client = new SendGridClient("sendgrid_key");
            var from = new EmailAddress("factura@staynchill.com", "Stay n'Chill");
            var subject = "Factura de Compra";
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
                    Precio
                </td>
            </tr>
            
            <tr class='item'>
                <td style='padding: 5px; vertical-align: top;'>
                    Membresía de Hotel
                </td>
                
                <td style='padding: 5px; vertical-align: top;'>
                    $" + $@"{totalPrice}" + @"
                </td>
            </tr>
            
            <tr class='total'>
                <td></td>
                
                <td>
                   Total: $" + $@"{totalPrice}" + @"
                </td>
            </tr>
        </table>
    </div>");

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
