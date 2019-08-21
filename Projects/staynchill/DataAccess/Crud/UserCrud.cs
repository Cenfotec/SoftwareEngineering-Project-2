﻿using DataAccess.Dao;
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
    public class UserCrud : CrudFactory
    {
        public UserCrud() : base(entityObjectMapper: new UserObjectMapper(), entityMapperGeneric: new UserMapper()) { }

        UserMapper userMapper = new UserMapper();

        public List<User> RetrieveAllById(int id, string cedula)
        {

            try
            {
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        userMapper.GetRetriveAllByIdStatement(id, cedula)
                    );

                if (lstResult.Count <= 0) return default(List<User>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<User>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }

        public List<User> RetrieveAllSubAdministradorByHotel(int idHotel)
        {

            try
            {
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        userMapper.GetRetriveAllSubAdministradorByHotelStatement(idHotel)
                    );

                if (lstResult.Count <= 0) return default(List<User>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<User>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }

        public T RetrieveByCorreo<T>(User user)
        {

            try
            {

                var instance = SqlDao.GetInstance();
                var operation = userMapper.GetRetriveByCorreoStatement(user.Correo);
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
      
        public T Validate<T>(string correo)
        {

            try
            {
                var instance = SqlDao.GetInstance();
                var operation = userMapper.Validate(correo);
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

        public async Task SendEmailAsync(string correo)
        {
            var contrasenna = RandomString();

            var client = new SendGridClient("sendgrid_key");
            var from = new EmailAddress("reset@staynchill.com", "Stay n'Chill");
            var subject = "Recuperar Contraseña";
            var to = new EmailAddress(correo);
            var plainTextContent = "";

            var htmlContent = string.Format(@"<div style='text-align:center;'>
        <div style='border-radius:20px 20px 0 0;display:inline-blocK;'>
            <div style='letter-spacing:1px;font-family: monospace,sans-serif;border-radius:12px 12px 0 0;background-color: #5D78FF;'>
                <p style='color:#FFF;font-size:1.5rem;padding:2rem 2rem 0 2rem;margin: 0;'>Contraseña Nueva</p>
                <p style='color:#F2F2F2;font-size:1rem;padding:0 2rem 2rem 2rem;margin:0;'>Stay n'Chill</p>
            </div>
            <div style='letter-spacing:10px;font-family: monospace,sans-serif;border-right: 1px dashed #BEBEBE;border-bottom: 1px dashed #BEBEBE;border-left: 1px dashed #BEBEBE;'>
                <div style='color:#171820;font-size:2.5rem;padding:2.25rem'>" + $@"{contrasenna}" + @"</div>
                </div>
        </div>
    </div>");

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            UpdateRecoveredPassword(correo, contrasenna);
        }

        public bool UpdateRecoveredPassword(string correo, string contrasenna)
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = userMapper.UpdateRecoveredPassword(correo, contrasenna);
                instance.ExecuteProcedure(operation);
            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return true;
        }

        public bool CreateAdminHotel(BaseEntity entity)
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = userMapper.CreateAdminHotel(entity);
                instance.ExecuteProcedure(operation);

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return true;
        }

        public bool CreateSubAdminHotel(BaseEntity entity)
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = userMapper.CreateSubAdminHotel(entity);
                instance.ExecuteProcedure(operation);

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return true;
        }

        public bool CreateFinal(BaseEntity entity)
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = userMapper.CreateFinal(entity);
                instance.ExecuteProcedure(operation);

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return true;
        }
    }
}
