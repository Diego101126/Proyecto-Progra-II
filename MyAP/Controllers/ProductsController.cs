using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using MyAPI.DTO;
using Services;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        private readonly ISvProduct _svProduct;
        public ProductsController(ISvProduct svProduct)
        {
            _svProduct = svProduct;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _svProduct.GetAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _svProduct.GetById(id);
        }





        //public Product Get(int id)
        //{
        //    return _svProduct.GetById(id);
        //}

        // POST api/<BooksController>
        [HttpPost]
        
        public ActionResult Post([FromBody] ProductDTO productDTO)
        {
            return Ok(_svProduct.Add(new Product() { Name = productDTO.Name, Provider = productDTO.Provieder, Inventory = productDTO.Inventory, Amount = productDTO.Amount, categoryId = productDTO.idCategory }));
        }




        //public void Post([FromBody] Product Product)
        //{
        //    _svProduct.Add(Product);
        //}

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProductDTO productDTO)
        {
            return Ok(_svProduct.Update(id, new Product() { Name = productDTO.Name, Provider = productDTO.Provieder, Inventory = productDTO.Inventory, Amount = productDTO.Amount}));
        }




        //public void Put(int id, [FromBody] Product Product)
        //{
        //    _svProduct.Update(id, Product);
        //}




        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _svProduct.Delete(id);
        }
    }
}
