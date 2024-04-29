using Domain.DTOs.StudentDto;
using Domain.Responses;
using Infrastructure.Services.StudentServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/Student")]
public class StudentController(IStudentService service) : ControllerBase
{
    [HttpGet("Get-Students")]
    public async Task<Response<List<GetStudentDto>>> GetStudent()
    {
        return await service.GetStudentsAsync();
    }

    [HttpGet("StudentId:int")]
    public async Task<Response<GetStudentDto>> GetStudentById(int StudentId)
    {
        return await service.GetStudentByIdAsync(StudentId);
    }

    [HttpPost("Add-Student")]
    public async Task<Response<string>> AddStudent(AddStudentDto add)
    {
        return await service.AddStudentAsync(add);
    }
    
    [HttpPut("Update-Student")]
    public async Task<Response<string>> UpdateStudent(UpdateStudentDto update)
    {
        return await service.UpdateStudentAsync(update);
    }

    [HttpDelete("StudentId:int")]
    public async Task<Response<bool>> DeleteStudent(int StudentId)
    {
        return await service.DeleteStudentAsync(StudentId);
    }

}
