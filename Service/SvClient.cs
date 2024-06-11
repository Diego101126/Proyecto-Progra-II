using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class SvClient : ISvClient
    {
        private readonly MyDbContext _myDbContext;
        public SvClient(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public Client Add(Client client)
        {
            _myDbContext.Clients.Add(client);
            _myDbContext.SaveChanges();

            return client;
        }

        public List<Client> GetAll()
        {
            return _myDbContext.Clients.Include("Purchases").ToList();
        }

        public Client GetById(int id)
        {
            return _myDbContext.Clients.Where(client => client.Id == id).First();
        }

        public void Delete(int id)
        {
            Client clientFound = _myDbContext.Clients.Where(client => client.Id == id).First();
            _myDbContext.Clients.Remove(clientFound);
            _myDbContext.SaveChanges();
        }

        public Client Update(int id, Client client)
        {
            Client clientFound = _myDbContext.Clients.Where(client => client.Id == id).First();


            clientFound.Name = client.Name;

            _myDbContext.Clients.Update(clientFound);
            _myDbContext.SaveChanges();

            return clientFound;
        }
    }
}
