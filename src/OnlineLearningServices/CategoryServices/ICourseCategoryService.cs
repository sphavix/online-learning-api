
using OnlineLearningCore.Domain.Dtos;
using OnlineLearningCore.Domain.Entities;

namespace OnlineLearningServices.CategoryServices
{
    public interface ICourseCategoryService
    {
        Task<CourseCategoryDto?> GetCategoryById(int id);
        Task<List<CourseCategoryDto>> GetCourseCategories();
    }
}
