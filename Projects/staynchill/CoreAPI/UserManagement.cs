using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class UserManagement
    {
        private UserCrud userCrud;

        public UserManagement() => userCrud = new UserCrud();

        public void Create(User user) => userCrud.Create(user);

        public void CreateFinal(User user) => userCrud.CreateFinal(user);

        public List<User> RetrieveAll() => userCrud.RetrieveAll<User>();

        public void CreateAdminHotel(User user) => userCrud.CreateAdminHotel(user);

        public void CreateSubAdminHotel(User user) => userCrud.CreateSubAdminHotel(user);

        public List<User> RetrieveAllById(int id, string cedula) => userCrud.RetrieveAllById(id, cedula);

	    public User Validate(string correo) => userCrud.Validate<User>(correo);

        public User RetrieveByCorreo(User user) => userCrud.RetrieveByCorreo<User>(user);

        public List<User> RetrieveAllSubAdministradorByHotel(int idHotel) => userCrud.RetrieveAllSubAdministradorByHotel(idHotel);

        public async Task SendEmailAsync(string correo) => await userCrud.SendEmailAsync(correo);

        public User Login(User user)
        {
            try
            {
                var tmpUser = new User() { Correo = user.Correo };
                User tmpU = RetrieveByCorreo(tmpUser);
                if (tmpU == null)
                {
                    // Usuario no existe
                    throw new BussinessException(1);
                }
                else
                {
                    // Encriptar utilizando MD5
                    MD5 md5 = new MD5CryptoServiceProvider();
                    md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(user.Contrasenna));
                    byte[] result = md5.Hash;
                    StringBuilder strBuilder = new StringBuilder();
                    for (int i = 0; i < result.Length; i++)
                    {
                        strBuilder.Append(result[i].ToString("x2"));
                    }

                    if (strBuilder.ToString().ToUpper().Equals(tmpU.Contrasenna))
                    {
                        tmpU.Contrasenna = "";
                        return tmpU;
                    }
                    else
                    {
                        // Credenciales incorrectos
                        throw new BussinessException(2);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return user;
        }

        public void Update(User user) => userCrud.Update(user);

    }
}
