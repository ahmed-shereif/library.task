using library.bll.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.bll.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAllCategory();
        public Task<CategoryDto> getCategoryById(int id);
        public Task<addCategoryDto> addCategory(addCategoryDto category);
        public Task<CategoryDto> updatCategory(int id, addCategoryDto category);
        public Task<bool> deleteCategoryById(int id);


    }
}
