using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes_Petar.Model
{
    public class ProductType
    {
        public int Id { get; set; } 

        public string TypeName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
