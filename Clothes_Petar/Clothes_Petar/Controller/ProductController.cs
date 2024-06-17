using Clothes_Petar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes_Petar.Controller
{
    public class ProductController
    {

        private ProductContext productController = new ProductContext();

        public Product Get(int id)
        {
            Product product = productController.Products.Find(id);
            if (product != null)
            {
                productController.Entry(product).Reference(x => x.ProductType).Load();
            }
            return product;
        }

        public List<Product> GetAll()
        {
            return productController.Products.Include("ProductType").ToList();
        }

        public void Create(Product product)
        {
            productController.Products.Add(product);
            productController.SaveChanges();
        }
        public void Update(int id, Product product)
        {
            Product _product = productController.Products.Find(id);
            if (_product == null)
            {
                return;
            }

            _product.Name = product.Name;
            _product.Price = product.Price;
            _product.Description = product.Description;
            _product.Size = product.Size;
            _product.Gender = product.Gender;
            _product.ProductTypeId = product.ProductTypeId;

            productController.SaveChanges();
        }
        public void Delete(int id)
        {
            Product product = productController.Products.Find(id);
            productController.Products.Remove(product);
            productController.SaveChanges();
        }

    }


}

