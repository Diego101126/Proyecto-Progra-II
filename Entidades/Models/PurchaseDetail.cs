using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PurchaseDetail
    {
        public int Id { get; set; }

        public int Amount { get; set; }
        public int Price { get; set; }

        public int payment { get; set; }

        public double Subtotal()
        {
            return Price * Amount;

        }

        

        //Relation

        //Purchase -> PurchaseDetail - One to One
        //public int PurchaseId { get; set; }

        //public Purchase Purchase { get; set; }



        public int purchaseId { get; set; }

        public Purchase purchase { get; set; } = new Purchase();


        //Relations
        //Product -> PurchaseDetail - One to Many


        public int productId { get; set; }

        public Product product = new Product();

        //public List<Product> ListProducts { get; set; } = new List<Product>();
    }


}

    

