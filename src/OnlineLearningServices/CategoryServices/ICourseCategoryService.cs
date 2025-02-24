
using OnlineLearningCore.Domain.Dtos;

namespace OnlineLearningServices.CategoryServices
{
    public interface ICourseCategoryService
    {
        Task<CourseCategoryDto?> GetCategoryById(int id);
        Task<List<CourseCategoryDto>> GetCourseCategories();
    }
}
