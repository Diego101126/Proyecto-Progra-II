using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public string Address { get; set; }

        //Relations
        //Cient -> Purchase - One to Many
        public List<Purchase> ListPurchases { get; set; } = new List<Purchase>();
    }
}
