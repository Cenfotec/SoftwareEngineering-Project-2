using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class CodeManagement
    {
        private CodeCrud codeCrud;

        public CodeManagement() => codeCrud = new CodeCrud();

        public async Task SendEmailAsync(string correo, string nombre) => await codeCrud.SendEmailAsync(correo, nombre);

        public Code getCodeConfirmation(string correo) => codeCrud.getCodeConfirmation(correo);

        public void Delete(Code codigo) => codeCrud.Delete(codigo);

    }
}
