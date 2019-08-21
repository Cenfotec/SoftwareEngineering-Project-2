using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
    public class ProductManagement {

        private ProductCrud crudProduct;

        public ProductManagement() => crudProduct = new ProductCrud();

        public void Create(Product product) => crudProduct.Create(product);

        public List<Product> RetrieveAll() => crudProduct.RetrieveAll<Product>();

        public Product RetrieveById(Product product) => crudProduct.Retrieve<Product>(product);

        public void Update(Product product) => crudProduct.Update(product);

        public void Delete(Product product) => crudProduct.Delete(product);
    }
}
