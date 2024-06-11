using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using MyAPI.DTO;
using Services;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController:ControllerBase
    {
        private readonly ISvPurchase _svPurchase;
        public PurchasesController(ISvPurchase svPurchase)
        {
            _svPurchase = svPurchase;
        }
        // GET: api/<BooksController>
        //[HttpGet]
        //public IEnumerable<Purchase> Get()
        //{
        //    return _svPurchase.GetAll();
        //}

        //// GET api/<BooksController>/5
        //[HttpGet("{id}")]
        //public Purchase Get(int id)
        //{
        //    return _svPurchase.GetById(id);
        //}

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult Post([FromBody] DTO.PurchesDTO purchesDTO )
        {
            return Ok(_svPurchase.Add(new Purchase() { clientId=purchesDTO.ClientId, DatePurchase=purchesDTO.DatePurchese, ProductId=purchesDTO.ProductId, Amount=purchesDTO.Amount}));
        }




        //public void Post([FromBody] Purchase Purchase)
        //{
        //    _svPurchase.Add(Purchase);
        //}








        // PUT api/<BooksController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] Purchase Purchase)
        //{
        //    _svPurchase.Update(id, Purchase);
        //}

        //// DELETE api/<BooksController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _svPurchase.Delete(id);
        //}
    }
}
