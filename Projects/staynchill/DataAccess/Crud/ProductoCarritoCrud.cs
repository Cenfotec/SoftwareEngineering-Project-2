using DataAccess.Dao;
using DataAccess.Mapper;
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
    public class ProductoCarritoCrud : CrudFactory
    {
        public ProductoCarritoCrud() : base(entityObjectMapper: new ProductoCarritoObjectMapper(), entityMapperGeneric: new ProductoCarritoMapper()) { }

        ProductoCarritoMapper ProductoCarritoMapper = new ProductoCarritoMapper();

        public List<ProductoCarrito> RetrieveAllByUser(int carrito)
        {
            try
            {
                ProductoCarritoMapper productoCarritoMapper = new ProductoCarritoMapper();
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        productoCarritoMapper.GetRetriveAllByIdStatement(carrito)
                    );

                if (lstResult.Count <= 0) return default(List<ProductoCarrito>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<ProductoCarrito>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }

        public async Task SendEmailCart(List<ProductoCarrito> productos, User user, CommissionHotel hotel)
        {
            var correo = user.Correo;
            var htmlContentProductList = "";
            decimal totalPrice = 0;
            for (int i = 0; i < productos.Count; i++)
            {
                totalPrice += productos.ElementAt(i).PrecioBruto;

                var htmlContentMain = string.Format(@"
            <tr class='item'>
                <td style='padding: 5px; vertical-align: top;'>
                    " + $@"{productos.ElementAt(i).NombreProducto}" + $@" (x{ productos.ElementAt(i).Cant})" + @"
                </td>
                
                <td style='padding: 5px; vertical-align: top;'>
                    $" + $@"{productos.ElementAt(i).PrecioBruto}" + @"
                </td>
            </tr>");
                htmlContentProductList += htmlContentMain;
            }
            

            var client = new SendGridClient("sendgrid_key");
            var from = new EmailAddress("compra@staynchill.com", "Stay n'Chill");
            var subject = "Factura de Compra";
            var to = new EmailAddress(correo);
            var plainTextContent = "";

            
            

            var htmlContent = string.Format(@"<div style='margin-top:5rem; max-width: 800px; margin: auto; padding: 30px; border: 1px solid #eee; box-shadow: 0 0 10px rgba(0, 0, 0, .15); font-size: 16px; line-height: 24px; font-family: 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif; color: #555; border-radius: 7px;'>
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
            
            " + $@"{htmlContentProductList}" + @"
            
            <tr class='total'>
                <td>
                    
                </td>
                <td>
                   Total: USD " + $@"{totalPrice}" + @"
                </td>
            </tr>
        </table>
    </div>");

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
