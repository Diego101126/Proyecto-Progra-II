using Entities.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyAPI.DTO;
using Services;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ISvClient _svClient;
        public ClientsController(ISvClient svClient)
        {
            _svClient = svClient;
        }
        // GET: api/<BooksController>
        //[HttpGet]
        //public IEnumerable<Client> Get()
        //{
        //    return _svClient.GetAll();
        //}

        //// GET api/<BooksController>/5
        //[HttpGet("{id}")]
        //public Client Get(int id)
        //{
        //    return _svClient.GetById(id);
        //}

        //POST api/<BooksController>
        [HttpPost]

        public ActionResult Post([FromBody]  ClientDTO clientDTO)
        {

            return Ok(_svClient.Add(new Client() { Name = clientDTO.Name, LastName = clientDTO.LastName, Email= clientDTO.Email, PhoneNumber= clientDTO.PhoneNumber, Address=clientDTO.Address  }));
        }

        



        //public void Post([FromBody] Client Client)
        //{
        //    _svClient.Add(Client);
        //}








        //// PUT api/<BooksController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] Client Client)
        //{
        //    _svClient.Update(id, Client);
        //}

        //// DELETE api/<BooksController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _svClient.Delete(id);
        //}
    }
}
