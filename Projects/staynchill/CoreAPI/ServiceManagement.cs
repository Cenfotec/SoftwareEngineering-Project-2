using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ServiceManagement
    {
        private ServiceCrud crudService;

        public ServiceManagement() => crudService = new ServiceCrud();

        public void Create(Service service) => crudService.Create(service);

        public List<Service> RetrieveAll() => crudService.RetrieveAll<Service>();

        public Service RetrieveById(Service service) => crudService.Retrieve<Service>(service);

        public List<Service> RetrieveAllByHotel(int idHotel) => crudService.RetrieveAllByHotel(idHotel);

        public void Update(Service service) => crudService.Update(service);

        public void Delete(Service service) => crudService.Delete(service);

    }
}
