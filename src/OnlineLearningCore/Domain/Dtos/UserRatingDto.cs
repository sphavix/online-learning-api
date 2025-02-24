namespace OnlineLearningCore.Domain.Dtos
{
    public class UserRatingDto
    {
        public int CourseId { get; set; }
        public decimal AverageRating { get; set; }
        public int TotalRating { get; set; }
    }
}
