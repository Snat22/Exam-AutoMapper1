using System.Data.Common;
using System.Net;
using AutoMapper;
using Domain.DTOs.StudentDto;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentServices;

public class StudentService(DataContext context,IMapper mapper):IStudentService
{
        public async Task<Response<string>> AddStudentAsync(AddStudentDto add)
    {
        try
        {
            var mapped = mapper.Map<Student>(add);
            await context.Students.AddAsync(mapped);
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


    public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int id)
    {
        try
        {
            var existing = await context.Students.FirstOrDefaultAsync(e=>e.Id==id);
            if(existing == null) return new Response<GetStudentDto>(HttpStatusCode.BadRequest,"Not Found!");
            var mapped = mapper.Map<GetStudentDto>(existing);
            return new Response<GetStudentDto>(mapped);
        }
        catch(DbException DBe)
        {
            return new Response<GetStudentDto>(HttpStatusCode.InternalServerError,DBe.Message);
        }
        catch (System.Exception e)
        {
            return new Response<GetStudentDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<GetStudentDto>>> GetStudentsAsync()
    {
        try
        {
            var Student = await context.Students.ToListAsync();
            if(Student == null) return new Response<List<GetStudentDto>>(HttpStatusCode.BadRequest,"Free");
            var mapped = mapper.Map<List<GetStudentDto>>(Student);
            return new Response<List<GetStudentDto>>(mapped);
        }
        catch(DbException DBe)
        {
            return new Response<List<GetStudentDto>>(HttpStatusCode.InternalServerError,DBe.Message);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetStudentDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateStudentAsync(UpdateStudentDto update)
    {
        try
        {
            var mapped = mapper.Map<Student>(update);
            context.Students.Update(mapped);
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
    public async Task<Response<bool>> DeleteStudentAsync(int id)
    {
        try
        {
                var course = await context.Students.Where(e=>e.Id==id).ExecuteDeleteAsync();
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
