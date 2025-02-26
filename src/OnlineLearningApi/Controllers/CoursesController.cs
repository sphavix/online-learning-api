using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningCore.Domain.Dtos;
using OnlineLearningServices.CourseServices;

namespace OnlineLearningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService courseService) : ControllerBase
    {
        private readonly ICourseService _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));

        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> GetCourses()
        {
            var courses = await _courseService.GetCoursesAsync();

            return Ok(courses);
        }

        [HttpGet("categories/{categoryId}")]
        public async Task<ActionResult<List<CourseDto>>> GetCoursesByCategory([FromRoute]int categoryId)
        {
            var courses = await _courseService.GetCoursesAsync(categoryId);

            return Ok(courses);
        }

        [HttpGet("details/{courseId:int}")]
        public async Task<ActionResult<List<CourseDto>>> GetCoursesByID([FromRoute] int courseId)
        {
            var courses = await _courseService.GetCourseDetailsAsync(courseId);

            if(courses == null)
            {
                return NotFound();
            }

            return Ok(courses);
        }
    }
}
