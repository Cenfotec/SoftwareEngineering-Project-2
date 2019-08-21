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
    public class CodeCrud : CrudFactory
    {
        public CodeCrud() : base(entityObjectMapper: new CodeObjectMapper(), entityMapperGeneric: new CodeMapper()) { }

        CodeMapper codeMapper = new CodeMapper();

        public string RandomString()
        {
            int size = 8;
            bool lowerCase = false;
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public async Task SendEmailAsync(string correo, string nombre)
        {
            var randomCode = RandomString();

            var client = new SendGridClient("sendgrid_key");
            var from = new EmailAddress("cuenta@staynchill.com", "Stay n'Chill");
            var subject = "Código de Confirmación";
            var to = new EmailAddress(correo);
            var plainTextContent = "";

            var htmlContent = string.Format(@"<div style='text-align:center;'>
        <div style='border-radius:20px 20px 0 0;display:inline-blocK;'>
            <div style='letter-spacing:1px;font-family: monospace,sans-serif;border-radius:12px 12px 0 0;background-color: #5D78FF;'>
                <p style='color:#FFF;font-size:1.5rem;padding:2rem 2rem 0 2rem;margin: 0;'>Código de Confirmación</p>
                <p style='color:#F2F2F2;font-size:1rem;padding:0 2rem 2rem 2rem;margin:0;'>Stay n'Chill</p>
            </div>
            <div style='letter-spacing:10px;font-family: monospace,sans-serif;border-right: 1px dashed #BEBEBE;border-bottom: 1px dashed #BEBEBE;border-left: 1px dashed #BEBEBE;'>
                <div style='color:#171820;font-size:2.5rem;padding:2.25rem'>" + $@"{randomCode}" + @"</div>
                </div>
        </div>
    </div>");

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            SaveCode(correo, randomCode);
        }

        public bool SaveCode(string correo, string code)
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = codeMapper.CodeStatement(correo, code);
                instance.ExecuteProcedure(operation);
            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return true;
        }

        public Code getCodeConfirmation(string correo)
        {
            try
            {
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        codeMapper.GetCodeStatement(correo)
                    );

                if (lstResult.Count <= 0) return default(Code);

                var obj = EntityObjectMapper.BuildObjects(lstResult);
          
                return obj.Cast<Code>().ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }
    }
}
