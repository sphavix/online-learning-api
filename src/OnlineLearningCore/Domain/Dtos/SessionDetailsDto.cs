
namespace OnlineLearningCore.Domain.Dtos
{
    public class SessionDetailsDto
    {
        public int SessionId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public string? Desciption { get; set; }
        public string? VideoUrl { get; set; }
        public int VideoOrder { get; set; }
    }
}
