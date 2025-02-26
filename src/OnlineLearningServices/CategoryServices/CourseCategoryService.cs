using OnlineLearningCore.Abstracts;
using OnlineLearningCore.Domain.Dtos;

namespace OnlineLearningServices.CategoryServices
{
    public class CourseCategoryService(ICourseCategoryRepository courseCategory) : ICourseCategoryService
    {
        private readonly ICourseCategoryRepository _courseCategory = courseCategory 
            ?? throw new ArgumentNullException(nameof(courseCategory));

        public async Task<CourseCategoryDto?> GetCategoryById(int id)
        {
            var course = await _courseCategory.GetCategoryById(id);

            return new CourseCategoryDto()
            {
                CategoryId = course!.CategoryId,
                CategoryName = course.CategoryName,
                Description = course.Description
            };
        }

        public async Task<List<CourseCategoryDto>> GetCourseCategories()
        {
            var courses = await _courseCategory.GetCourseCategories();

            return courses.Select(x => new CourseCategoryDto()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();
        }
    }
}
