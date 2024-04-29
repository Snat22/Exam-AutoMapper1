using Domain.DTOs.CourseDtos;
using Domain.DTOs.StudentDto;
using Domain.Responses;
using Infrastructure.Services.QueryServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[Queries]")]
public class QueryController(IQueryService service) : ControllerBase
{
    [HttpGet("Get-Sub-Count")]
    public async Task<Response<List<StudentSubmissionCountDto>>> GetStudentSubmissionCounts()
    {
        return await service.GetStudentSubmissionCounts();
    }
    
    [HttpGet("Get-COursName")]
    public async Task<Response<List<GetStudentDto>>> GetStudentsWithoutSubmissions(string courseName)
    {
        return await service.GetStudentsWithoutSubmissions(courseName
        );
    }
    
    [HttpGet("Get-COurse-Material")]
    public async Task<Response<List<CourseMaterialCountDto>>> GetCourseMaterialCounts()
    {
        return await service.GetCourseMaterialCounts();
    }
    
    [HttpGet("Get-All-Submission")]
    public async  Task<Response<List<GetStudentDto>>> GetStudentsWithAllTimelySubmissions()
    {
        return await service.GetStudentsWithAllTimelySubmissions();
    }

}
