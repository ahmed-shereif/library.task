using librar.data.Data;
using librar.data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librar.data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        public CategoryRepository(libraryDbContext libraryDbCont)
        {
            LibraryDbCont = libraryDbCont;
        }

        public libraryDbContext LibraryDbCont { get; }

        public async Task<Category> addCategory(Category category)
        {
            var result = await LibraryDbCont.Category.AddAsync(category);
            await LibraryDbCont.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> deleteCategoryById(int id)
        {
            var result = await LibraryDbCont.Category.FirstOrDefaultAsync(b => b.CategoryId == id);
            if (result != null)
            {
                LibraryDbCont.Category.Remove(result);
                await LibraryDbCont.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> getaAllCategorys()
        {
            var category = await LibraryDbCont.Category
                                     .Include(b => b.Book) // Load the Category navigation property
                                     .ToListAsync();


            return category;
        }

        public async Task<Category> GetCategory(int id)
        {
            var result = await LibraryDbCont.Category.Include(b => b.Book).FirstOrDefaultAsync(b => b.CategoryId == id);
            if (result != null)
            {

                return result;
            }
            return null;
        }

        public async Task<Category> updatCategory(Category category)
        {
            var updatedCategory = await LibraryDbCont.Category.FirstOrDefaultAsync(b => b.CategoryId == category.CategoryId);
            if (updatedCategory != null)
            {
                updatedCategory.Description = category.Description;
                updatedCategory.Name = category.Name;
                await LibraryDbCont.SaveChangesAsync();
                return updatedCategory;
            }
            return null;



        }
    }
}
