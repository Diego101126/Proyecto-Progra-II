using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISvCategory
    {
        public Category Add(Category category);
        public List<Category> GetAll();
        public Category GetById(int id);
        public void Delete(int id);
        public Category Update(int id, Category category);
    }
}
