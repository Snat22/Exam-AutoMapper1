using System.Net;
using AutoMapper;
using Domain.DTOs.AssignmentDtos;
using Domain.DTOs.StudentDto;
using Domain.DTOs.SubmissionDto;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.SubmissionServices;

public class SubmissionService(DataContext context, IMapper mapper) : ISubmissionService
{
    public async Task<Response<string>> SubmitAssignment(AddStudentDto student, AddAssignmentDto assignments)
    {
        try
        {
            var assignment = mapper.Map<Assignment>(assignments);
            var std = mapper.Map<Student>(student);

            await context.Assignments.AddAsync(assignment);
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return new Response<string>(assignment.Title);
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
    public async Task<Response<List<GetSubmissionDto>>> GetSubmissionsForAssignment(int assignmentId)
    {
        try
        {
            
        var submission = await context.Submissions.Where(e=>e.AssignmentId==assignmentId).ToListAsync();

        var mapped = mapper.Map<List<GetSubmissionDto>>(submission).ToList();
        return new Response<List<GetSubmissionDto>>(mapped);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetSubmissionDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<GetSubmissionDto>> GetSubmissionById(int id)
    {
        try
        {
            var submission = await context.Submissions.FirstOrDefaultAsync(e=>e.Id==id);
            if(submission==null)return new Response<GetSubmissionDto>(HttpStatusCode.BadRequest,"Not Found");
            var mapped = mapper.Map<GetSubmissionDto>(submission);
            return new Response<GetSubmissionDto>(mapped);
        }
        catch (System.Exception e)
        {
            return new Response<GetSubmissionDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

}






