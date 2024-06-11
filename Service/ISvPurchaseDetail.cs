using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISvPurchaseDetail
    {
        public PurchaseDetail Add(PurchaseDetail purchaseDetail);
        public List<PurchaseDetail> GetAll();
        public PurchaseDetail GetById(int id);
        public void Delete(int id);
        public PurchaseDetail Update(int id, PurchaseDetail purchaseDetail);
    }
}
