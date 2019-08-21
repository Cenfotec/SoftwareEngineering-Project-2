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
using static Entities_POJO.InfoChatBot;

namespace DataAccess.Crud
{
    public class CommissionCrud : CrudFactory
    {
        public CommissionCrud() : base(entityObjectMapper: new CommissionObjectMapper(), entityMapperGeneric: new CommissionMapper()) { }
        CommissionMapper commisionMapper = new CommissionMapper();

        public Commission IsAdminHotelRegistered(int fkHotel)
        {
            try
            {
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        commisionMapper.IsAdminHotelRegistered(fkHotel)
                    );

                if (lstResult.Count <= 0) return null;

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Commission>().ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }

        public void Create2(UsuarioChat fkHotel)
        {
            try
            {
                InfoChatBotMapper mapper = new InfoChatBotMapper();
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        mapper.CreateUser(fkHotel)
                    );

            }
            catch (Exception e)
            {
                ManageException(e);
            }

        }

        public bool TrueOrFalse(Commission commission)
        {
            if (commission != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task Email(EmailMembership email)
        {
            var correo = email.Percentage;

            var status = TrueOrFalse(IsAdminHotelRegistered(email.FkHotel));

            var client = new SendGridClient("sendgrid_key");
            var from = new EmailAddress("solicitud@staynchill.com", "Stay n'Chill");
            var subject = "Confirmación de Solicitud";
            var to = new EmailAddress(correo);
            var plainTextContent = "";

            var emailTitle = "Confirmar solicitud de hotel";
            var emailButtonText = "CONFIRMAR SOLICITUD";
            var emailBody = "Hola, gracias por solicitar la inscripción de hotel. Para proceder con la confirmación de la solicitud, presione el botón.";
            var emailFooter = "Presione el botón para confirmar la solicitud de hotel";

            // IF dependiendo si ya tiene 1 hotel o no
            var emailLink = "";
            if (status)
            {
                emailLink = "http://localhost:54388/dashboard/register/adminhotel";
            }
            else
            {
                emailLink = "http://localhost:54388/register/adminhotel";
            }

            var htmlContent = string.Format(@"<body class='full-padding' style='margin: 0;padding: 0;-webkit-text-size-adjust: 100%;'>
<!--<![endif]-->
    <table class='wrapper' style='border-collapse: collapse;table-layout: fixed;min-width: 320px;width: 100%;background-color: #f0f0f0;' cellpadding='0' cellspacing='0' role='presentation'><tbody><tr><td>
      <div role='banner'>
        <div class='preheader' style='Margin: 0 auto;max-width: 560px;min-width: 280px; width: 280px;width: calc(28000% - 167440px);'>
          <div style='border-collapse: collapse;display: table;width: 100%;'>
          <!--[if (mso)|(IE)]><table align='center' class='preheader' cellpadding='0' cellspacing='0' role='presentation'><tr><td style='width: 280px' valign='top'><![endif]-->
            <div class='snippet' style='display: table-cell;Float: left;font-size: 12px;line-height: 19px;max-width: 280px;min-width: 140px; width: 140px;width: calc(14000% - 78120px);padding: 10px 0 5px 0;color: #bdbdbd;font-family: Ubuntu,sans-serif;'>
              
            </div>
          <!--[if (mso)|(IE)]></td><td style='width: 280px' valign='top'><![endif]-->
            <div class='webversion' style='display: table-cell;Float: left;font-size: 12px;line-height: 19px;max-width: 280px;min-width: 139px; width: 139px;width: calc(14100% - 78680px);padding: 10px 0 5px 0;text-align: right;color: #bdbdbd;font-family: Ubuntu,sans-serif;'>
              
            </div>
          <!--[if (mso)|(IE)]></td></tr></table><![endif]-->
          </div>
        </div>
        
      </div>
      <div>
      <div class='layout one-col fixed-width' style='Margin: 0 auto;max-width: 600px;min-width: 320px; width: 320px;width: calc(28000% - 167400px);overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;'>
        <div class='layout__inner' style='border-collapse: collapse;display: table;width: 100%;background-color: #ffffff;' emb-background-style>
        <!--[if (mso)|(IE)]><table align='center' cellpadding='0' cellspacing='0' role='presentation'><tr class='layout-fixed-width' emb-background-style><td style='width: 600px' class='w560'><![endif]-->
          <div class='column' style='text-align: left;color: #787778;font-size: 16px;line-height: 24px;font-family: Ubuntu,sans-serif;max-width: 600px;min-width: 320px; width: 450px;width: calc(28000% - 167400px);'>
        
            <div style='Margin-left: 20px;Margin-right: 20px;Margin-top: 24px;'>
      <div style='mso-line-height-rule: exactly;line-height: 20px;font-size: 1px;'>&nbsp;</div>
    </div>
        
            <div style='Margin-left: 20px;Margin-right: 20px;'>
      <div style='mso-line-height-rule: exactly;mso-text-raise: 4px;'>
        <h1 style='Margin-top: 0;Margin-bottom: 0;font-style: normal;font-weight: normal;color: #565656;font-size: 30px;line-height: 38px;text-align: center;'><strong>" + $@"{emailTitle}" + @"</strong></h1><p style='Margin-top: 20px;Margin-bottom: 20px;'>&nbsp;<br />
" + $@"{emailBody}" + @"</p>
      </div>
    </div>
        
            <div style='Margin-left: 20px;Margin-right: 20px;'>
      <div style='mso-line-height-rule: exactly;line-height: 10px;font-size: 1px;'>&nbsp;</div>
    </div>
        
            <div style='Margin-left: 20px;Margin-right: 20px;'>
      <div class='btn btn--flat btn--large' style='Margin-bottom: 20px;text-align: center;'>
        <![if !mso]><a style='border-radius: 4px;display: inline-block;font-size: 14px;font-weight: bold;line-height: 24px;padding: 12px 24px;text-align: center;text-decoration: none !important;transition: opacity 0.1s ease-in;color: #ffffff !important;background-color: #80bf2e;font-family: Ubuntu, sans-serif;' href='"
        
        
        + $@"{emailLink}" + @"?id=" + $@"{email.FkHotel}" + @"&Zpi3Lv2kMB0RzGz5TjMSkRJZ1Y7t10I6jpbHhx2pzjMZpi3Lv2kMB0RzGz5TjMSkRJZ1Y7t10I6jpbHhx2pzjM=" + $@"{email.membershipPrice}" + @"'
        
        >" + $@"{emailButtonText}" + @"</a><![endif]>
      <!--[if mso]><p style='line-height:0;margin:0;'>&nbsp;</p><v:roundrect xmlns:v='urn:schemas-microsoft-com:vml' href='http://test.com' style='width:219px' arcsize='9%' fillcolor='#80BF2E' stroke='f'><v:textbox style='mso-fit-shape-to-text:t' inset='0px,11px,0px,11px'><center style='font-size:14px;line-height:24px;color:#FFFFFF;font-family:Ubuntu,sans-serif;font-weight:bold;mso-line-height-rule:exactly;mso-text-raise:4px'>COMPLETE THE<br>
SURVEY</center></v:textbox></v:roundrect><![endif]--></div>
    </div>
        
            <div style='Margin-left: 20px;Margin-right: 20px;'>
      <div style='mso-line-height-rule: exactly;line-height: 10px;font-size: 1px;'>&nbsp;</div>
    </div>
        
            <div style='Margin-left: 20px;Margin-right: 20px;'>
      <div style='mso-line-height-rule: exactly;mso-text-raise: 4px;'>
        <p style='Margin-top: 0;Margin-bottom: 20px;'><em>" + $@"{emailFooter}" + @"</em></p>
      </div>
    </div>
        
            <div style='Margin-left: 20px;Margin-right: 20px;Margin-bottom: 24px;'>
      <div style='mso-line-height-rule: exactly;line-height: 5px;font-size: 1px;'>&nbsp;</div>
    </div>
        
          </div>
        <!--[if (mso)|(IE)]></td></tr></table><![endif]-->
        </div>
      </div>
  
      <div style='line-height:10px;font-size:10px;'>&nbsp;</div>
    </div></td></tr></tbody></table>
  
</body>");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public List<Commission> getCommission(Commission cedulaJuridicaDeHotel)
        {

            try
            {
                CommissionMapper commissionMapper = new CommissionMapper();
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        commissionMapper.GetCommissionStatement(cedulaJuridicaDeHotel)
                    );

                if (lstResult.Count <= 0) return default(List<Commission>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Commission>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }
    }
}
