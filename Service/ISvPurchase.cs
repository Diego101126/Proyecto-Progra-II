using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISvPurchase
    {
        public Purchase Add(Purchase purchaseTools);
        public List<Purchase> GetAll();
        public Purchase GetById(int id);
        public void Delete(int id);
        public Purchase Update(int id, Purchase purchase);
    }
}
