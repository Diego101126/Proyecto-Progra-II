using Entities.Models;

namespace Services
{
    public interface ISvProduct
    {
        public Product Add(Product product);
        public List<Product> GetAll();
        public Product GetById(int id);
        public void Delete(int id);
        public Product Update(int id, Product product);
    }
}
