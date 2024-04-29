using Domain.DTOs.AssignmentDtos;
using Domain.Responses;
using Infrastructure.Services.AssignmentServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[Assignment]")]
public class AssignmentController(IAssignmentService service) : ControllerBase
{
    [HttpGet("Get-Assignments")]
    public async Task<Response<List<GetAssignmentDto>>> GetAssignment()
    {
        return await service.GetAssignmentsAsync();
    }

    [HttpGet("assignmentId:int")]
    public async Task<Response<GetAssignmentDto>> GetAssignmentById(int assignmentId)
    {
        return await service.GetAssignmentByIdAsync(assignmentId);
    }

    [HttpPost("Add-Assignment")]
    public async Task<Response<string>> AddAssignment(AddAssignmentDto add)
    {
        return await service.AddAssignmentAsync(add);
    }
    
    [HttpPut("Update-Assignment")]
    public async Task<Response<string>> UpdateAssignment(UpdateAssignmentDto update)
    {
        return await service.UpdateAssignmentAsync(update);
    }

    [HttpDelete("assignmentId:int")]
    public async Task<Response<bool>> DeleteAssignment(int assignmentId)
    {
        return await service.DeleteAssignmentAsync(assignmentId);
    }
}
