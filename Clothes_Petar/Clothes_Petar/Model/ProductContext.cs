using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes_Petar.Model
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("ProductContext")
        {

        }

        public DbSet<Product> Products { get; set; } //table DogS
        public DbSet<ProductType> productTypes { get; set; }//table Breeds



    }
}
