using OnlineLearningCore.Domain.Entities;

namespace OnlineLearningCore.Abstracts
{
    public interface ICourseCategoryRepository
    {
        Task<CourseCategory?> GetCategoryById(int id);
        Task<List<CourseCategory>> GetCourseCategories();
    }
}
