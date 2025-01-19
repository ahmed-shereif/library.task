using AutoMapper;
using librar.data.Entities;
using librar.data.Repositories;
using library.bll.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.bll.Services
{
    public class CategoryService : ICategoryService
    {

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {

            CategoryRepository = categoryRepository;
            Mapper = mapper;
        }

        public ICategoryRepository CategoryRepository { get; }
        public IMapper Mapper { get; }

        public async Task<addCategoryDto> addCategory(addCategoryDto category)
        {



            var newCat = Mapper.Map<Category>(category);
            var res = await CategoryRepository.addCategory(newCat);


            return Mapper.Map<addCategoryDto>(category);
        }

        public async Task<bool> deleteCategoryById(int id)
        {
            var res = await CategoryRepository.deleteCategoryById(id);
            return res;
        }

      

        public async Task<IEnumerable<CategoryDto>> GetAllCategory()
        {
            IEnumerable<Category> categories = await CategoryRepository.getaAllCategorys();
            IEnumerable<CategoryDto> categoryDtos = Mapper.Map<IEnumerable<CategoryDto>>(categories);
            foreach (CategoryDto categoryDto in categoryDtos)
            {
                IEnumerable<Book> books = categories.FirstOrDefault(x => x.CategoryId == categoryDto.CategoryId).Book;
                IEnumerable<BookDto> booksDto = Mapper.Map<IEnumerable<BookDto>>(books);
                categoryDto.Books = booksDto;
            }
            return categoryDtos;
        }

        public async Task<CategoryDto> getCategoryById(int id)
        {
            var category = await CategoryRepository.GetCategory(id);

            CategoryDto catDto = Mapper.Map<CategoryDto>(category);
            catDto.Books = Mapper.Map<IEnumerable<BookDto>>(category.Book);
            if (category == null)
            {
                // Handle not found case, e.g., throw an exception or return null
                throw new KeyNotFoundException($"category with ID {id} not found.");
            }

            // Use AutoMapper to map Book to BookDto
            return catDto;
        }

        public async Task<CategoryDto> updatCategory(int id, addCategoryDto addCategoryDto)
        {
            Category cat= await CategoryRepository.GetCategory(id);
            cat.Name = addCategoryDto.Name;
            cat.Description = addCategoryDto.Description;

            var res = await CategoryRepository.updatCategory(cat);

            if (res == null)
            {
                return null; // Book not found or update failed
            }

            // Map the updated Book entity back to BookDto
            return Mapper.Map<CategoryDto>(res);
        }
    }
}
