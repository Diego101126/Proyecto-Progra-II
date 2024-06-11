using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISvClient
    {
        public Client Add(Client client);
        public List<Client> GetAll();
        public Client GetById(int id);
        public void Delete(int id);
        public Client Update(int id, Client client);
    }
}
