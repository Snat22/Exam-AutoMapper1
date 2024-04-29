using System.Data.Common;
using System.Net;
using AutoMapper;
using Domain.DTOs.FeedbackDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.FeedbackServices;

public class FeedbackService(DataContext context,IMapper mapper):IFeedbackService
{
    public async Task<Response<GetFeedbackDto>> ProvideFeedback(int FeedbackId,AddFeedbackDto feedback)
    {
        foreach (var item in context.Feedbacks)
        {
            var add = new Feedback
            {
                Id = item.Id,
                Text = item.Text
            };
            
        }

        var mapped = mapper.Map<GetFeedbackDto>(add);
        return new Response<GetFeedbackDto>(mapped);
    }


public async Task<Response<List<GetFeedbackDto>>> GetFeedbackForAssignment(int assignmentId)
{
    try
    {
    var feedbacks = await context.Feedbacks.Where(f => f.AssignmentId == assignmentId).ToListAsync();

    var mapped = mapper.Map<List<GetFeedbackDto>>(feedbacks);
    return new Response<List<GetFeedbackDto>>(mapped);
    }
    catch (System.Exception e)
    {
    return new Response<List<GetFeedbackDto>>(HttpStatusCode.InternalServerError,e.Message);
    }
}

    public async Task<Response<GetFeedbackDto>> GetFeedbackById(int id)
    {
        try
        {
            
            var feedback = await context.Feedbacks.FirstOrDefaultAsync(e=>e.Id==id);
            if(feedback==null)return new Response<GetFeedbackDto>(HttpStatusCode.BadRequest,"Not Found");
            var mapped = mapper.Map<GetFeedbackDto>(feedback);
            return new Response<GetFeedbackDto>(mapped);
        }
        catch (System.Exception e)
        {
            return new Response<GetFeedbackDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

}
