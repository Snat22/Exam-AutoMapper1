using Domain.DTOs.FeedbackDtos;
using Domain.Responses;
using Infrastructure.Services.FeedbackServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[Feedback]")]
public class FeedbackController(IFeedbackService service) : ControllerBase
{
    
    [HttpGet("Get-Feedback")]
    public async Task<Response<GetFeedbackDto>> ProvideFeedback(int submissionId,AddFeedbackDto feedback)
    {
        return await service.ProvideFeedback(submissionId, feedback);
    }

    [HttpGet("assignmentId:int")]
    public async Task<Response<List<GetFeedbackDto>>> GetFeedbackForAssignment(int assignmentId)
    {
        return await service.GetFeedbackForAssignment(assignmentId);
    }

    [HttpPost("id:int")]
    public async Task<Response<GetFeedbackDto>> GetFeedbackById(int id)
    {
        return await service.GetFeedbackById(id);
    }
    
}
