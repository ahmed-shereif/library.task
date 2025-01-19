using librar.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librar.data.Repositories
{
    public interface ICategoryRepository
    {

        public Task<IEnumerable<Category>> getaAllCategorys();
        public Task<Category> GetCategory(int id);

        public Task<Category> addCategory(Category category);
        public Task<Category> updatCategory(Category Categorybook);
        public Task<bool> deleteCategoryById(int id);

    }
}
