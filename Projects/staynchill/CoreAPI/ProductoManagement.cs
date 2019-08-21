using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ProductoManagement
    {
        private ProductoCrud crudProducto;

        public ProductoManagement() => crudProducto = new ProductoCrud();

        public void Create(Producto producto)
        {
            try
            {
                producto.Id = 0;
                producto.State = "Enabled";
                producto.Type = "Product";
                if (producto.Value == null)
                {
                    producto.Value = "N/A";
                }

                crudProducto.Create(producto);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Producto> RetrieveAll() => crudProducto.RetrieveAll<Producto>();

        public List<Producto> GetRetriveAllByHotelServicioStatement(int idHotel, int idService) => crudProducto.GetRetriveAllByHotelServicioStatement(idHotel, idService);

        public Producto RetrieveById(Producto producto) => crudProducto.Retrieve<Producto>(producto);

        public void Update(Producto producto) => crudProducto.Update(producto);

        public void Delete(Producto producto) => crudProducto.Delete(producto);
    }
}
