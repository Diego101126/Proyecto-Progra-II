using Entities.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyAPI.DTO;
using Services;


namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController: ControllerBase
    {
        private readonly ISvCategory _svCategory;
        public CategoriesController(ISvCategory svCategory)
        {
            _svCategory = svCategory;
        }
        // GET: api/<BooksController>
        //[HttpGet]
        //public IEnumerable<Category> Get()
        //{
        //    return _svCategory.GetAll();
        //}

        //// GET api/<BooksController>/5
        //[HttpGet("{id}")]
        //public Category Get(int id)
        //{
        //    return _svCategory.GetById(id);
        //}

        // POST api/<BooksController>
        [HttpPost]

        
        public ActionResult Post([FromBody] CategoryDTO categotyDTO)
        {

            return Ok(_svCategory.Add(new Category() { Name = categotyDTO.Name }));
        }

        // PUT api/<BooksController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] Category Category)
        //{
        //    _svCategory.Update(id, Category);
        //}

        //// DELETE api/<BooksController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _svCategory.Delete(id);
        //}
    }
}
