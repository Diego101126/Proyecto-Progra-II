using Entities;
using Entities.Models;


namespace Services
{
    public class SvProduct : ISvProduct

    {

        private readonly MyDbContext _myDbContext;

        // Esta es la forma de inyectar nuestro MyDbContext para que el servicio SvUser puede utilizarlo en sus metodos
        // Cuando se inyecta cualquier servicio, interfaz o clase se hace en el constructor de esta manera (Siempre)
        // El contenedor de dependencias sabe que tiene que pasar el servicio por el parámetro del constructor y así poder utilizarlo
        public SvProduct(MyDbContext myDbContext) //Aquí viene el MyDbContext inyectado desde el proyecto DataAccess
        
        {
            _myDbContext = myDbContext;
        }

        public Product Add(Product product)
        {

            var category = _myDbContext.Categories.FirstOrDefault(x=>x.Id == product.categoryId);
            product.category = category;

            _myDbContext.Products.Add(product);
            _myDbContext.SaveChanges();

            return product;
        }
        public Product Update(int id, Product product)
        {

            //var productRequest = _mapper.Map<Product>(product);

            //var category  =_myDbContext.Categories.FirstOrDefault(x => x.Id == product.categoryId);

            //var productUpdate = _myDbContext.Products.FirstOrDefault(x => x.Id == product.Id);


            //productUpdate.Name = productRequest.Name;
            //productUpdate.Provider = productRequest.Provider;
            //productUpdate.Inventory = productRequest.Inventory;
            //productUpdate.Amount= productRequest.Amount;




            //return productUpdate;



            var productUpdate = _myDbContext.Products.FirstOrDefault(x => x.ProductId == id);
            productUpdate.Name = product.Name;
            productUpdate.Provider= product.Provider;
            productUpdate.Inventory = product.Inventory;
            productUpdate.Amount= product.Amount;


            //Product ProductFound = _myDbContext.Products.Where(product => product.Id == id).First();
            //ProductFound.Id = product.Id;

            _myDbContext.Products.Update(productUpdate);
            _myDbContext.SaveChanges();

            return productUpdate;
        }

        public List<Product> GetAll()
        {
            return _myDbContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _myDbContext.Products.Where(Product => Product.ProductId == id).First();
        }

        public void Delete(int id)
        {
            Product ProductFound = _myDbContext.Products.Where(Product => Product.ProductId == id).First();
            _myDbContext.Products.Remove(ProductFound);
            _myDbContext.SaveChanges();
        }

        
    }
}
