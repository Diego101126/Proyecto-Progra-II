using Entities.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class SvPurchaseDetail:ISvPurchaseDetail
    {
        private readonly MyDbContext _myDbContext;
        public SvPurchaseDetail(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public PurchaseDetail Add(PurchaseDetail purchaseDetail)
        {
            var PurchaseDetail = _myDbContext.Purchases.FirstOrDefault(x=>x.ProductId == purchaseDetail.purchaseId);
            var PurchaseProduct = _myDbContext.Products.FirstOrDefault(x=>x.ProductId==purchaseDetail.purchaseId);


            purchaseDetail.purchase = PurchaseDetail;
            purchaseDetail.product = PurchaseProduct;


            _myDbContext.PurchaseDetails.Add(purchaseDetail);

            return purchaseDetail;
        }

        public List<PurchaseDetail> GetAll()
        {
            return _myDbContext.PurchaseDetails.Include("Products").ToList();
        }

        public PurchaseDetail GetById(int id)
        {
            return _myDbContext.PurchaseDetails.Where(purchaseDetail => purchaseDetail.Id == id).First();
        }

        public void Delete(int id)
        {
            PurchaseDetail purchaseDetailFound = _myDbContext.PurchaseDetails.Where(purchaseDetail => purchaseDetail.Id == id).First();
            _myDbContext.PurchaseDetails.Remove(purchaseDetailFound);
            _myDbContext.SaveChanges();
        }

        public PurchaseDetail Update(int id, PurchaseDetail purchaseDetail)
        {
            PurchaseDetail purchaseDetailFound = _myDbContext.PurchaseDetails.Where(purchaseDetail => purchaseDetail.Id == id).First();


            purchaseDetailFound.Id = purchaseDetail.Id;

            _myDbContext.PurchaseDetails.Update(purchaseDetailFound);
            _myDbContext.SaveChanges();

            return purchaseDetailFound;
        }
    }
}
