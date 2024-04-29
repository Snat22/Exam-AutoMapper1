using Domain.DTOs.CourseDtos;
using Domain.Responses;
using Infrastructure.Services.CourseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/Course")]
public class CourseController(ICourseService service) : ControllerBase
{
    
    [HttpGet("Get-Courses")]
    public async Task<Response<List<GetCourseDto>>> GetCourse()
    {
        return await service.GetCoursesAsync();
    }

    [HttpGet("CourseId:int")]
    public async Task<Response<GetCourseDto>> GetCourseById(int CourseId)
    {
        return await service.GetCourseByIdAsync(CourseId);
    }

    [HttpPost("Add-Course")]
    public async Task<Response<string>> AddCourse(AddCourseDto add)
    {
        return await service.AddCourseAsync(add);
    }
    
    [HttpPut("Update-Course")]
    public async Task<Response<string>> UpdateCourse(UpdateCourseDto update)
    {
        return await service.UpdateCourseAsync(update);
    }

    [HttpDelete("CourseId:int")]
    public async Task<Response<bool>> DeleteCourse(int CourseId)
    {
        return await service.DeleteCourseAsync(CourseId);
    }
}
