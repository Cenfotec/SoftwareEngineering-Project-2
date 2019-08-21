using DataAccess.Crud;
using Entities_POJO;
using System.Collections.Generic;

namespace Core
{
    public class AdvertisementManagement
    {

        private AdvertisementCrud advertisementCrud;

        public AdvertisementManagement() => advertisementCrud = new AdvertisementCrud();

        public void Create(Advertisement advertisement) => advertisementCrud.Create(advertisement);

        public List<Advertisement> RetrieveAll() => advertisementCrud.RetrieveAll<Advertisement>();

        public Advertisement RetrieveById(Advertisement advertisement) => advertisementCrud.Retrieve<Advertisement>(advertisement);

        public void Update(Advertisement advertisement) => advertisementCrud.Update(advertisement);

        public void Delete(Advertisement advertisement) => advertisementCrud.Delete(advertisement);
    }
}
