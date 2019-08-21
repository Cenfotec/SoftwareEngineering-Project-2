using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class VistaReservacionManagement
    {
        private VistaReservacionCrud reservacionCrud;

        public VistaReservacionManagement() => reservacionCrud = new VistaReservacionCrud();

        public List<VistaReservacion> RetrieveAllReservacion(int id) => reservacionCrud.RetrieveAllPermisos(id);

    }
}
