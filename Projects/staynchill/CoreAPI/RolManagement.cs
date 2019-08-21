using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class RolManagement
    {
        private RolCrud rolCrud;

        public RolManagement() => rolCrud = new RolCrud();

        public void Create(Rol rol) => rolCrud.Create(rol);

        public void Associate(Rol rol)
        {
            rol.PermisosString = (rol.PermisosString == null) ? "" : rol.PermisosString;
            rolCrud.Associate(rol);
        }

        public List<Rol> RetrieveAllByIdHotel(int idHotel) => rolCrud.RetrieveAllByIdHotel(idHotel);

        public Rol Validate(Rol rol) => rolCrud.Validate<Rol>(rol);

        public List<Rol> RetrieveAllPermisos() => rolCrud.RetrieveAllPermisos();

        public List<Rol> RetrieveAllPermisosByUsuario(User user) => rolCrud.RetrieveAllPermisosByUsuario(user);

        public List<Rol> RetrieveAllByUser(Rol rol) => rolCrud.RetrieveAllByUser(rol);

        public void Delete(Rol rol) => rolCrud.DeleteRol(rol);

    }
}
