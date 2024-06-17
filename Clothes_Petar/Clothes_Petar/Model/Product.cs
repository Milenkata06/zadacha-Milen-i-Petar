using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes_Petar.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string Size { get; set; }

        public string Gender { get; set; }

        public int ProductTypeId { get; set; } //F.K
        //M:1
        public ProductType ProductType { get; set; }

    }
}
