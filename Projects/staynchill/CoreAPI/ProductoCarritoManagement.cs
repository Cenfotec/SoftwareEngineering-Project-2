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
    public class ProductoCarritoManagement
    {
        private ProductoCarritoCrud crudProductoCarrito;

        public ProductoCarritoManagement() => crudProductoCarrito = new ProductoCarritoCrud();

        public void Create(ProductoCarrito productoCarrito) => crudProductoCarrito.Create(productoCarrito);

        public List<ProductoCarrito> RetrieveAll() => crudProductoCarrito.RetrieveAll<ProductoCarrito>();

        public ProductoCarrito RetrieveById(ProductoCarrito productoCarrito) => crudProductoCarrito.Retrieve<ProductoCarrito>(productoCarrito);

        public List<ProductoCarrito> RetrieveAllByUser(int carrito) => crudProductoCarrito.RetrieveAllByUser(carrito);

        public void Update(ProductoCarrito productoCarrito) => crudProductoCarrito.Update(productoCarrito);

        public void Delete(ProductoCarrito productoCarrito) => crudProductoCarrito.Delete(productoCarrito);

        public void CreateList(ArrayProductos productos)
        {
            try
            {
                for (int i = 0; i < productos.productsArray.Count; i++)
                {
                    productos.productsArray.ElementAt(i).Fecha = DateTime.Now;
                    Create(productos.productsArray.ElementAt(i));
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public async Task SendEmailCart(List<ProductoCarrito> productos, User user, CommissionHotel hotel) => await crudProductoCarrito.SendEmailCart(productos, user, hotel);

    }
}
