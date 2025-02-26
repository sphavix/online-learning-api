using OnlineLearningCore.Abstracts;
using OnlineLearningCore.Domain.Dtos;

namespace OnlineLearningServices.CourseServices
{
    public class CourseService(ICourseRepository courseRepository) : ICourseService
    {
        private readonly ICourseRepository _courseRepository = courseRepository
            ?? throw new ArgumentNullException(nameof(courseRepository));

        public async Task<CourseDetailsDto> GetCourseDetailsAsync(int courseId)
        {
            return await _courseRepository.GetCourseDetailsAsync(courseId);
        }

        public async Task<List<CourseDto>> GetCoursesAsync(int? categoryId = null)
        {
            return await _courseRepository.GetCoursesAsync(categoryId);
        }
    }
}
