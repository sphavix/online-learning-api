using Microsoft.EntityFrameworkCore;
using OnlineLearningCore.Abstracts;
using OnlineLearningPersistence.Persistence;
using OnlineLearningPersistence.Repositories;
using OnlineLearningServices.CategoryServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OnlineCourseDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineCourse"),
        provideOptions => provideOptions.EnableRetryOnFailure());
});


builder.Services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
builder.Services.AddScoped<ICourseCategoryService, CourseCategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();
