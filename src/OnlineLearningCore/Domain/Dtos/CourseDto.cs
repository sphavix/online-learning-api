﻿namespace OnlineLearningCore.Domain.Dtos
{
    public class CourseDto
    {
        public int CourseId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string CourseType { get; set; } = null!;

        public int? SeatsAvailable { get; set; }

        public decimal Duration { get; set; }

        public int CategoryId { get; set; }

        public int InstructorId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Thumbnail { get; set; }

        public CourseCategoryDto Category { get; set; } = null!;
        public UserRatingDto UserRating { get; set; } = null!;
    }
}
