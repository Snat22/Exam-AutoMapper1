using System.Data.Common;
using System.Net;
using AutoMapper;
using Domain.DTOs.AssignmentDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.AssignmentServices;

public class AssignmentService(DataContext context, IMapper mapper) : IAssignmentService
{
    public async Task<Response<string>> AddAssignmentAsync(AddAssignmentDto add)
    {
        try
        {
            var mapped = mapper.Map<Assignment>(add);
            await context.Assignments.AddAsync(mapped);
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.Accepted,"Added");
        }
        catch(DbException DBe)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,DBe.Message);
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


    public async Task<Response<GetAssignmentDto>> GetAssignmentByIdAsync(int id)
    {
        try
        {
            var existing = await context.Assignments.FirstOrDefaultAsync(e=>e.Id==id);
            if(existing == null) return new Response<GetAssignmentDto>(HttpStatusCode.BadRequest,"Not Found!");
            var mapped = mapper.Map<GetAssignmentDto>(existing);
            return new Response<GetAssignmentDto>(mapped);
        }
        catch(DbException DBe)
        {
            return new Response<GetAssignmentDto>(HttpStatusCode.InternalServerError,DBe.Message);
        }
        catch (System.Exception e)
        {
            return new Response<GetAssignmentDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<GetAssignmentDto>>> GetAssignmentsAsync()
    {
        try
        {
            var assignment = await context.Assignments.ToListAsync();
            if(assignment == null) return new Response<List<GetAssignmentDto>>(HttpStatusCode.BadRequest,"Free");
            var mapped = mapper.Map<List<GetAssignmentDto>>(assignment);
            return new Response<List<GetAssignmentDto>>(mapped);
        }
        catch(DbException DBe)
        {
            return new Response<List<GetAssignmentDto>>(HttpStatusCode.InternalServerError,DBe.Message);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetAssignmentDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateAssignmentAsync(UpdateAssignmentDto update)
    {
        try
        {
            var mapped = mapper.Map<Assignment>(update);
            context.Assignments.Update(mapped);
            var upd = await context.SaveChangesAsync();
            if(upd == 0) return new Response<string>(HttpStatusCode.BadRequest,"Not Found");
            
            return new Response<string>(HttpStatusCode.OK,"Yet Updated");
        }
        catch(DbException DBe)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,DBe.Message);
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
    public async Task<Response<bool>> DeleteAssignmentAsync(int id)
    {
        try
        {
                var course = await context.Assignments.Where(e=>e.Id==id).ExecuteDeleteAsync();
                if(course== 0) return new Response<bool>(HttpStatusCode.BadRequest,"Not Found!",false);
                return new Response<bool>(HttpStatusCode.OK,true);

        }
        catch(DbException DBe)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,DBe.Message);
        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

}
