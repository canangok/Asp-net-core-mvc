using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Entity.Concrete;

namespace TestProject.MVCWebUI.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
    }
}
