using System.Net;
using AutoMapper;
using Domain.DTOs.CourseDtos;
using Domain.DTOs.StudentDto;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.QueryServices;


public class QueryService(DataContext context,IMapper mapper) : IQueryService
// Методы
{
    public async Task<Response<List<StudentSubmissionCountDto>>> GetStudentSubmissionCounts()
{
    try
    {
        
    var submissionCounts = await context.Submissions
        .GroupBy(s => s.StudentId)
        .Select(g => new { StudentId = g.Key, Count = g.Count() })
        .OrderByDescending(x => x.Count)
        .ToListAsync();

    var studentSubmissionCounts = submissionCounts.Select(x => new StudentSubmissionCountDto
    {
        StudentName = context.Students.Find(x.StudentId).Name,
        SubmissionCount = x.Count
    }).ToList();

    return new Response<List<StudentSubmissionCountDto>>(studentSubmissionCounts);
    }
    catch (System.Exception e)
    {
        return new Response<List<StudentSubmissionCountDto>>(HttpStatusCode.InternalServerError,e.Message);
    }
}

public async Task<Response<List<GetStudentDto>>> GetStudentsWithoutSubmissions(string courseName)
{
    try
    {
        
    var courseId = context.Courses.FirstOrDefault(c => c.Title == courseName)?.Id;

    var studentsWithSubmissions = context.Submissions
        .Where(s => s.Id == courseId)
        .Select(s => s.StudentId)
        .Distinct();

    var studentsWithoutSubmissions = context.Students
        .Where(s => !studentsWithSubmissions.Contains(s.Id))
        .ToList();

    var studentDtos = mapper.Map<List<GetStudentDto>>(studentsWithoutSubmissions);
    return new Response<List<GetStudentDto>>(studentDtos);
    }
    catch (System.Exception e)
    {
        return new Response<List<GetStudentDto>>(HttpStatusCode.InternalServerError,e.Message);
    }
}

public async Task<Response<List<CourseMaterialCountDto>>> GetCourseMaterialCounts()
{
    try
    {
        
    var materialCounts = await context.Courses
        .Select(c => new { CourseId = c.Id, Count = c.Material.Count })
        .ToListAsync();

    var courseMaterialCounts = materialCounts.Select(x => new CourseMaterialCountDto
    {
        CourseName = context.Courses.Find(x.CourseId).Name,
        MaterialCount = x.Count
    }).ToList();

    return new Response<List<CourseMaterialCountDto>>(courseMaterialCounts);
    }
    catch (System.Exception e)
    {
        return new Response<List<CourseMaterialCountDto>>(HttpStatusCode.InternalServerError,e.Message);
    }
}

public async Task<Response<List<GetStudentDto>>> GetStudentsWithAllTimelySubmissions()
{
    try
    {
        
    var studentsWithLateSubmissions = context.Submissions
        .Where(s => s.SubmissionDate > s.Assignment.DueDate)
        .Select(s => s.StudentId)
        .Distinct();

    var studentsWithAllTimelySubmissions = context.Students
        .Where(s => !studentsWithLateSubmissions.Contains(s.Id))
        .ToList();

    var studentDtos = mapper.Map<List<GetStudentDto>>(studentsWithAllTimelySubmissions);
    return new Response<List<GetStudentDto>>(studentDtos);
    }
    catch (System.Exception e)
    {
        return new Response<List<GetStudentDto>>(HttpStatusCode.InternalServerError,e.Message);
    }
}

}
