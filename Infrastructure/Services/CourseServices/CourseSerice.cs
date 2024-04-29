using System.Data.Common;
using System.Net;
using AutoMapper;
using Domain.DTOs.CourseDtos;
using Domain.DTOs.MaterialDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.CourseServices;

public class CourseSerice(DataContext context,IMapper mapper):ICourseService
{
        public async Task<Response<string>> AddCourseAsync(AddCourseDto add)
    {
        try
        {
            var mapped = mapper.Map<Course>(add);
            await context.Courses.AddAsync(mapped);
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


    public async Task<Response<GetCourseDto>> GetCourseByIdAsync(int id)
    {
        try
        {
            var existing = await context.Courses.FirstOrDefaultAsync(e=>e.Id==id);
            if(existing == null) return new Response<GetCourseDto>(HttpStatusCode.BadRequest,"Not Found!");
            var mapped = mapper.Map<GetCourseDto>(existing);
            return new Response<GetCourseDto>(mapped);
        }
        catch(DbException DBe)
        {
            return new Response<GetCourseDto>(HttpStatusCode.InternalServerError,DBe.Message);
        }
        catch (System.Exception e)
        {
            return new Response<GetCourseDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<GetCourseDto>>> GetCoursesAsync()
    {
        try
        {
            var Course = await context.Courses.ToListAsync();
            if(Course == null) return new Response<List<GetCourseDto>>(HttpStatusCode.BadRequest,"Free");
            var mapped = mapper.Map<List<GetCourseDto>>(Course);
            return new Response<List<GetCourseDto>>(mapped);
        }
        catch(DbException DBe)
        {
            return new Response<List<GetCourseDto>>(HttpStatusCode.InternalServerError,DBe.Message);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetCourseDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateCourseAsync(UpdateCourseDto update)
    {
        try
        {
            var mapped = mapper.Map<Course>(update);
            context.Courses.Update(mapped);
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
    public async Task<Response<bool>> DeleteCourseAsync(int id)
    {
        try
        {
                var course = await context.Courses.Where(e=>e.Id==id).ExecuteDeleteAsync();
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

    // Query
    public Task<Response<GetCourseWithMaterialsDto>> GetCourseWithMaterialsAsync(int courseId)
{
        var query = context.Courses.Where(c=>c.Id==courseId).Select(c=>new GetCourseWithMaterialsDto
        {
            CourseId = c.Id,
            CourseName = c.Title,
            Material = context.Materials.Where(m=>m.CourseId==courseId).Select(m=>new GetMaterialDto
            {
                Id = m.Id,
                CourseId = m.CourseId,
                Title = m.Title,
                Description = m.Description,
                ContentUrl = m.ContentUrl

            }).ToListAsync()
        });
        
        var mapped = mapper.Map<List<GetCourseWithMaterialsDto>>(query);

                    return new Task<Response<GetCourseWithMaterialsDto>>(mapped);

        // var courseWithMaterials = context.Courses
        //     .Where(c => c.Id == courseId)
        //     .Select(c => new GetCourseWithMaterialsDto
        //     {
        //         CourseId = c.Id,
        //         CourseName = c.Title,
        //         Materials = context.Materials
        //             .Where(m => m.CourseId == courseId)
        //             .Select(m => new Material
        //             {
        //                 Id = m.Id,
        //                 CourseId = m.CourseId,
        //                 Title = m.Title,
        //                 Description = m.Description,
        //                 ContentUrl = m.ContentUrl
        //             })
        //             .ToList()
        //     });
    }

        }