using Domain.DTOs.AssignmentDtos;
using Domain.DTOs.StudentDto;
using Domain.DTOs.SubmissionDto;
using Domain.Responses;
using Infrastructure.Services.SubmissionServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[Submission]")]
public class SubmissionController(ISubmissionService service) : ControllerBase
{
    [HttpGet("Get-SubmitAssignment")]
    public async Task<Response<string>>SubmitAssignment(AddStudentDto student, AddAssignmentDto assignment)
    {
        return await service.SubmitAssignment(student,assignment);
    }

    [HttpGet("assignmentId:int")]
    public async Task<Response<GetSubmissionDto>> GetSubmissionsForAssignment(int assignmentId)
    {
        return await service.GetSubmissionsForAssignment(assignmentId);
    }

    [HttpPost("id:int")]
    public async Task<Response<GetSubmissionDto>> GetSubmissionById(int id)
    {
        return await service.GetSubmissionById(id);
    }
    

}
