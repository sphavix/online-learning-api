using OnlineLearningCore.Domain.Dtos;

namespace OnlineLearningCore.Abstracts
{
    public interface ICourseRepository
    {
        Task<List<CourseDto>> GetCoursesAsync(int? categoryId = null);
        Task<CourseDetailsDto> GetCourseDetailsAsync(int courseId);
    }
}
