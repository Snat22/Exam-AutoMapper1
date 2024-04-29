using Domain.DTOs.FeedbackDtos;
using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services.FeedbackServices;

public interface IFeedbackService
{
    public Task<Response<GetFeedbackDto>> ProvideFeedback(int submissionId,AddFeedbackDto feedback);
    public Task<Response<List<GetFeedbackDto>>> GetFeedbackForAssignment(int assignmentId);
    public Task<Response<GetFeedbackDto>> GetFeedbackById(int id);

}
