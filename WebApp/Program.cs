using Domain.Models;
using Infrastructure.AutoMapper;
using Infrastructure.Data;
using Infrastructure.Services.AssignmentServices;
using Infrastructure.Services.CourseServices;
using Infrastructure.Services.FeedbackServices;
using Infrastructure.Services.MaterialServices;
using Infrastructure.Services.QueryServices;
using Infrastructure.Services.StudentServices;
using Infrastructure.Services.SubmissionServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options=>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddScoped<IAssignmentService,AssignmentService>();
builder.Services.AddScoped<ICourseService,CourseSerice>();
builder.Services.AddScoped<IFeedbackService,FeedbackService>();
builder.Services.AddScoped<IMaterialService,MaterialService>();
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<ISubmissionService,SubmissionService>();
builder.Services.AddScoped<IQueryService,QueryService>();


builder.Services.AddAutoMapper(typeof(MapperProfile));

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

