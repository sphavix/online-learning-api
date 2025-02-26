using OnlineLearningCore.Domain.Dtos;

namespace OnlineLearningServices.CourseServices
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetCoursesAsync(int? categoryId = null);
        Task<CourseDetailsDto> GetCourseDetailsAsync(int courseId);
    }
}
