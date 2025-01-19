using library.bll.DTOs;
using library.bll.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace library.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        public CategoryController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        public ICategoryService CategoryService { get; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            IEnumerable<CategoryDto> cats = await CategoryService.GetAllCategory();
            return Ok(cats);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> getCategoryById(int id)
        {
            try
            {
                var Cat = await CategoryService.getCategoryById(id);
                if (Cat == null)
                {
                    return NotFound($" {id} id is not found");
                }
                else
                {
                    return Ok(Cat);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<addCategoryDto>> AddCategory([FromBody] addCategoryDto categoryDto)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }

            try
            {
                // Attempt to add the book
                var addedCat = await CategoryService.addCategory(categoryDto);
                // Return the added book with a Created (201) status
                return CreatedAtAction(nameof(AddCategory), addedCat);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex);


            }



        }


        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> UpdateBook(int id, [FromBody] addCategoryDto updatedCatDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            var cat = await CategoryService.updatCategory(id, updatedCatDto);
            if (cat == null)
            {
                return StatusCode(500, "An error occurred while saving the Cat.");

            }
            return Ok(cat);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> deleteCatById(int id)
        {
            bool res = await CategoryService.deleteCategoryById(id);
            if (res == true)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "An error occurred while saving the Cat.");

            }
        }

    }
}
