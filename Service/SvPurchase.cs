using Entities.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;

namespace Services
{
    public class SvPurchase : ISvPurchase
    {
        private readonly MyDbContext _myDbContext;

        // Esta es la forma de inyectar nuestro MyDbContext para que el servicio SvUser puede utilizarlo en sus metodos
        // Cuando se inyecta cualquier servicio, interfaz o clase se hace en el constructor de esta manera (Siempre)
        // El contenedor de dependencias sabe que tiene que pasar el servicio por el parámetro del constructor y así poder utilizarlo
        public SvPurchase(MyDbContext myDbContext) //Aquí viene el MyDbContext inyectado desde el proyecto DataAccess

        {
            _myDbContext = myDbContext;
        }

        public Purchase Add(Purchase purchase)
        {
            var client = _myDbContext.Clients.FirstOrDefault(x => x.Id == purchase.clientId) ?? throw new Exception("El cliente no existe!");
            purchase.client = client;
            _myDbContext.Purchases.Add(purchase);    
            _myDbContext.SaveChanges();
            var body = $"<h1>Gracias por tu compra</h1>";//Esto se puede modificar a tu gusto
            SendEmail(client.Email, body);
            return purchase;
        }
        private void SendEmail(string emailDestino, string body)
        {
            string emailOrigen = "xxxxxxxxxxxxxxxxxxxxxxxxxx";
            string password = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            MailMessage mailMessage = new(emailOrigen, emailDestino, "Nueva compra 👌", body);
            mailMessage.IsBodyHtml = true;
            var smtpClient = new SmtpClient
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential { UserName = emailOrigen, Password = password }
            };
            smtpClient.Send(mailMessage);
        }

        public List<Purchase> GetAll()
        {
            return _myDbContext.Purchases.ToList();
        }

        public Purchase GetById(int id)
        {
            return _myDbContext.Purchases.Where(Purchase => Purchase.Id == id).First();
        }

        public void Delete(int id)
        {
            Purchase PurchaseFound = _myDbContext.Purchases.Where(Purchase => Purchase.Id == id).First();
            _myDbContext.Purchases.Remove(PurchaseFound);
            _myDbContext.SaveChanges();
        }

        public Purchase Update(int id, Purchase Purchase)
        {
            Purchase PurchaseFound = _myDbContext.Purchases.Where(Purchase => Purchase.Id == id).First();
            PurchaseFound.Id = Purchase.Id;

            _myDbContext.Purchases.Update(PurchaseFound);
            _myDbContext.SaveChanges();

            return PurchaseFound;
        }

        public Purchase AddProductToPurchase(int Id, int productId, int quantity)
        {
            var purchase = _myDbContext.Purchases.FirstOrDefault(p => Id == Id) ?? throw new Exception("La compra no existe!");
            var product = _myDbContext.Products.FirstOrDefault(p => Id == Id) ?? throw new Exception("El producto no existe!");

            var purchaseProduct = new Purchase
            {
                Id = Id,
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = Id,
                
            };

            _myDbContext.Purchases.Add(purchaseProduct);
            _myDbContext.SaveChanges();

            // Update purchase total with the new product's price including tax
            purchase.TotalAmount += purchaseProduct.TotalPriceWithTax;
            _myDbContext.Purchases.Update(purchase);
            _myDbContext.SaveChanges();

            return purchase;
        }

    }
}
    

