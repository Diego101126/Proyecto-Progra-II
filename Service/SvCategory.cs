using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class SvCategory:ISvCategory
    {
        private readonly MyDbContext _myDbContext;
        public SvCategory(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public Category Add(Category category)
        {
            _myDbContext.Categories.Add(category);
            _myDbContext.SaveChanges();

            return category;
        }

        public List<Category> GetAll()
        {
            return _myDbContext.Categories.Include("Products").ToList();
        }

        public Category GetById(int id)
        {
            return _myDbContext.Categories.Where(category => category.Id == id).First();
        }

        public void Delete(int id)
        {
            Category categoryFound = _myDbContext.Categories.Where(category => category.Id == id).First();
            _myDbContext.Categories.Remove(categoryFound);
            _myDbContext.SaveChanges();
        }

        public Category Update(int id, Category category)
        {
            Category categoryFound = _myDbContext.Categories.Where(category => category.Id == id).First();

            
            categoryFound.Name = category.Name;

            _myDbContext.Categories.Update(categoryFound);
            _myDbContext.SaveChanges();

            return categoryFound;
        }
    }
}
