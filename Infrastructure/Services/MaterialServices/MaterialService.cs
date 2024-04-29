using System.Data.Common;
using System.Net;
using AutoMapper;
using Domain.DTOs.MaterialDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.MaterialServices;

public class MaterialService(DataContext context,IMapper mapper):IMaterialService
{
    public async Task<Response<string>> AddMaterialAsync(AddMaterialDto add)
    {
        try
        {
            var mapped = mapper.Map<Material>(add);
            await context.Materials.AddAsync(mapped);
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


    public async Task<Response<GetMaterialDto>> GetMaterialByIdAsync(int id)
    {
        try
        {
            var existing = await context.Materials.FirstOrDefaultAsync(e=>e.Id==id);
            if(existing == null) return new Response<GetMaterialDto>(HttpStatusCode.BadRequest,"Not Found!");
            var mapped = mapper.Map<GetMaterialDto>(existing);
            return new Response<GetMaterialDto>(mapped);
        }
        catch(DbException DBe)
        {
            return new Response<GetMaterialDto>(HttpStatusCode.InternalServerError,DBe.Message);
        }
        catch (System.Exception e)
        {
            return new Response<GetMaterialDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<GetMaterialDto>>> GetMaterialsAsync()
    {
        try
        {
            var Material = await context.Materials.ToListAsync();
            if(Material == null) return new Response<List<GetMaterialDto>>(HttpStatusCode.BadRequest,"Free");
            var mapped = mapper.Map<List<GetMaterialDto>>(Material);
            return new Response<List<GetMaterialDto>>(mapped);
        }
        catch(DbException DBe)
        {
            return new Response<List<GetMaterialDto>>(HttpStatusCode.InternalServerError,DBe.Message);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetMaterialDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateMaterialAsync(UpdateMaterialDto update)
    {
        try
        {
            var mapped = mapper.Map<Material>(update);
            context.Materials.Update(mapped);
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
    public async Task<Response<bool>> DeleteMaterialAsync(int id)
    {
        try
        {
                var course = await context.Materials.Where(e=>e.Id==id).ExecuteDeleteAsync();
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
