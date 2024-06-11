using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using MyAPI.DTO;
using Services;


namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseDetailsController:ControllerBase
    {
        private readonly ISvPurchaseDetail _svPurchaseDetail;
        public PurchaseDetailsController(ISvPurchaseDetail svPurchaseDetail)
        {
            _svPurchaseDetail = svPurchaseDetail;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<PurchaseDetail> Get()
        {
            return _svPurchaseDetail.GetAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public PurchaseDetail Get(int id)
        {
            return _svPurchaseDetail.GetById(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult Post([FromBody] PurchaseDetailDTO purchaseDetail)
        {
            return Ok(_svPurchaseDetail.Add(new PurchaseDetail {Amount = purchaseDetail.Amount, Price= purchaseDetail.Price, payment= purchaseDetail.Payment, /*Iva= purchaseDetail.Iva, Descount= purchaseDetail.Descount, total= purchaseDetail.Total,*/ purchaseId= purchaseDetail.purchaseId, productId = purchaseDetail.productId}));


        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PurchaseDetail PurchaseDetail)
        {
            _svPurchaseDetail.Update(id, PurchaseDetail);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _svPurchaseDetail.Delete(id);
        }
    }
}
