using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class UbicationManagement
    {
        private UbicationCrud crudUbication;

        public UbicationManagement() => crudUbication = new UbicationCrud();

        public void Create(Ubication ubication) => crudUbication.Create(ubication);

        public List<Ubication> RetrieveAll() => crudUbication.RetrieveAll<Ubication>();

        public Ubication RetrieveById(Ubication ubication) => crudUbication.Retrieve<Ubication>(ubication);

        public void Update(Ubication ubication) => crudUbication.Update(ubication);

    }
}
