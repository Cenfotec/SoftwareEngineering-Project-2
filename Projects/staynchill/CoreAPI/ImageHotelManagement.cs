using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ImageHotelManagement
    {
        private ImageHotelCrud crudImage;

        public ImageHotelManagement() => crudImage = new ImageHotelCrud();

        public void Create(ImageHotel image) => crudImage.Create(image);

        public List<ImageHotel> RetrieveAll() => crudImage.RetrieveAll<ImageHotel>();

        public ImageHotel RetrieveById(ImageHotel image) => crudImage.Retrieve<ImageHotel>(image);

        public void Update(ImageHotel image) => crudImage.Update(image);

        public void Delete(ImageHotel image) => crudImage.Delete(image);

    }
}
