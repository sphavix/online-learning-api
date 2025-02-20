using Microsoft.EntityFrameworkCore;
using OnlineLearningCore.Abstracts;
using OnlineLearningCore.Domain.Entities;
using OnlineLearningPersistence.Persistence;

namespace OnlineLearningPersistence.Repositories
{
    public class CourseCategoryRepository(OnlineCourseDbContext context) : ICourseCategoryRepository
    {
        private readonly OnlineCourseDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<CourseCategory?> GetCategoryById(int id)
        {
            var course = await _context.CourseCategories.FindAsync(id);

            return course;
        }

        public async Task<List<CourseCategory>> GetCourseCategories()
        {
            var courses = await _context.CourseCategories.ToListAsync();

            return courses;
        }
    }
}
