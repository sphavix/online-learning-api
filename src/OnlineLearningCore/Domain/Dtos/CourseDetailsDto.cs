namespace OnlineLearningCore.Domain.Dtos
{
    public class CourseDetailsDto : CourseDto
    {
        public List<UserReviewDto> Reviews { get; set; } = new List<UserReviewDto>();
        public List<SessionDetailsDto> SessionDetails { get; set; } = new List<SessionDetailsDto>();
    }
}
