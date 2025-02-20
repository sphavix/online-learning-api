using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningCore.Domain.Dtos;
using OnlineLearningServices.CategoryServices;

namespace OnlineLearningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICourseCategoryService categoryService) : ControllerBase
    {
        private readonly ICourseCategoryService _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCourseCategories();

            var response = new List<CourseCategoryDto>();

            foreach(var category in categories)
            {
                response.Add(new CourseCategoryDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                });
            }

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

           if(category == null)
           {
                return NotFound();
           }

            // Map domain to Dto
            var response = new CourseCategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };

           return Ok(response);
        }
    }
}
