using Microsoft.EntityFrameworkCore;
using OnlineLearningCore.Abstracts;
using OnlineLearningCore.Domain.Dtos;
using OnlineLearningPersistence.Persistence;

namespace OnlineLearningPersistence.Repositories
{
    public class CourseRepository(OnlineCourseDbContext context) : ICourseRepository
    {
        private readonly OnlineCourseDbContext _context = context 
            ?? throw new ArgumentNullException(nameof(context));

        public async Task<List<CourseDto>> GetCoursesAsync(int? categoryId = null)
        {
            var query = _context.Courses.Include(x => x.Category).AsQueryable();

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }

            var courses = await query.Select(x =>
                new CourseDto
                {
                    CourseId = x.CourseId,
                    Title = x.Title,
                    Description = x.Description,
                    Price = x.Price,
                    CourseType = x.CourseType,
                    SeatsAvailable = x.SeatsAvailable,
                    Duration = x.Duration,
                    CategoryId = x.CategoryId,
                    InstructorId = x.InstructorId,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Category = new CourseCategoryDto
                    {
                        CategoryId = x.Category.CategoryId,
                        CategoryName = x.Category.CategoryName,
                        Description = x.Category.Description
                    },
                    UserRating = new UserRatingDto
                    {
                        CourseId = x.CourseId,
                        AverageRating = x.Reviews.Any() ? Convert.ToDecimal(x.Reviews.Average(ar => ar.Rating)) : 0,
                        TotalRating = x.Reviews.Count
                    }
                }).ToListAsync();

            return courses;

        }

        public async Task<CourseDetailsDto> GetCourseDetailsAsync(int courseId)
        {
            var course = await _context.Courses.Include(c => c.Category)
                    .Include(c => c.Reviews)
                    .Include(c => c.SessionDetails)
                    .Where(x => x.CourseId == courseId)
                    .Select(x => new CourseDetailsDto
                    {
                        CourseId = x.CourseId,
                        Title = x.Title,
                        Description = x.Description,
                        Price = x.Price,
                        CourseType = x.CourseType,
                        SeatsAvailable = x.SeatsAvailable,
                        Duration = x.Duration,
                        CategoryId = x.CategoryId,
                        InstructorId = x.InstructorId,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        Category = new CourseCategoryDto
                        {
                            CategoryId = x.Category.CategoryId,
                            CategoryName = x.Category.CategoryName,
                            Description = x.Category.Description
                        },
                        Reviews = x.Reviews.Select( r => new UserReviewDto
                        {
                            CourseId = r.CourseId,
                            UserName = r.User.DisplayName,
                            Rating = r.Rating,
                            Comments = r.Comments,
                            ReviewDate = r.ReviewDate
                        }).OrderByDescending(o => o.Rating).Take(10).ToList(),
                        SessionDetails = x.SessionDetails.Select(s => new SessionDetailsDto
                        {
                            SessionId = s.SessionId,
                            CourseId = s.CourseId,
                            Title = s.Title,
                            Desciption = s.Description,
                            VideoUrl = s.VideoUrl,
                            VideoOrder = s.VideoOrder
                        }).OrderBy(x => x.VideoOrder).ToList(),
                        UserRating = new UserRatingDto
                        {
                            CourseId = x.CourseId,
                            AverageRating = x.Reviews.Any() ? Convert.ToDecimal(x.Reviews.Average(ar => ar.Rating)) : 0,
                            TotalRating = x.Reviews.Count
                        }
                    }).FirstOrDefaultAsync();

            return course!;
            
        }
        
    }
}
