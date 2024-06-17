using Clothes_Petar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes_Petar.Controller
{
    public class ProductTypeController
    {
        private ProductContext typeController = new ProductContext();

        public List<ProductType> GetAllProductTypes()
        {
            return typeController.productTypes.ToList();
        }

        public string GetProductTypeById(int id)
        {
            return typeController.productTypes.Find(id).TypeName;
        }


    }
}
