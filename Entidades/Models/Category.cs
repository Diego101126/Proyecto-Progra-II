using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Relations

        //Product -> Category - One to Many 

        public List<Product> ListProducts { get; set; } = new List<Product>();
    }
}
