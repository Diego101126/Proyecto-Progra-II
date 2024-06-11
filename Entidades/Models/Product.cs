using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Provider { get; set; }

        public int Inventory { get; set; }


        public string Amount { get; set; }


        //Relations

        //Product -> Category - Many to One



        public int categoryId { get; set; }
        public int purchaseDetailId { get; set; }


        public Category category { get; set; } = new Category();



        public List<PurchaseDetail> ListpurchaseDetails { get; set; } =new List<PurchaseDetail>();

        //public PurchaseDetail? purchaseDetail { get; /*set*/; } = new PurchaseDetail();


        //public int CategoryId { get; set; }

        //public Category? Category { get; set; }

         
         
    }
}
