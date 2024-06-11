using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public string DatePurchase { get; set; }

        public string Amount { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalPriceWithoutTax => Quantity * UnitPrice;
        public decimal TaxRate { get; set; } = 0.13m; // IVA del 13%
        public decimal TaxAmount => TotalPriceWithoutTax * TaxRate;
        public decimal TotalPriceWithTax => TotalPriceWithoutTax + TaxAmount;

        //Relations

        //Cient -> Purchase - One to Many





        public int clientId { get; set; }

        public Client client { get; set; }=new Client();

        //public int ClientId { get; set; }

        //public Client Client { get; set; }


        //Purchase -> PurchaseDetail - One to One


        public List<PurchaseDetail> ListpurchaseDetail { get; set; }= new List<PurchaseDetail>();
        public int ProductId { get; set; }

        //public PurchaseDetail purchaseDetail { get; set; }





        //public int purchaseDetailId { get; set; }


        //public PurchaseDetail purchaseDetail { get; set; } = new PurchaseDetail();


        //public int PurchaseDetailId { get; set; }

        //public PurchaseDetail? PurchaseDetail { get; set; }
    }

    public class PurchaseTools
    {
        public int Id { get; set; }
        public string? DatePurchase { get; set; }
        public int ClientId { get; set; }
        //public List<PurchaseDetailTools> details { get; set; } = new List< PurchaseDetailTools>();
    }


    public class PurchaseDetailTools
    {
        public int Amount { get; set; }
        public int Price { get; set; }
        public int Payment { get; set; }
        public double Iva { get; set; }
        public double Descount { get; set; }
        public double Total { get; set; }
        public int ProductId { get; set; }

    }

}


