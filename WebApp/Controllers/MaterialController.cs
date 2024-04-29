using Domain.DTOs.MaterialDtos;
using Domain.Responses;
using Infrastructure.Services.MaterialServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[Material]")]
public class MaterialController(IMaterialService service) : ControllerBase
{ [HttpGet("Get-Materials")]
    public async Task<Response<List<GetMaterialDto>>> GetMaterial()
    {
        return await service.GetMaterialsAsync();
    }

    [HttpGet("MaterialId:int")]
    public async Task<Response<GetMaterialDto>> GetMaterialById(int MaterialId)
    {
        return await service.GetMaterialByIdAsync(MaterialId);
    }

    [HttpPost("Add-Material")]
    public async Task<Response<string>> AddMaterial(AddMaterialDto add)
    {
        return await service.AddMaterialAsync(add);
    }
    
    [HttpPut("Update-Material")]
    public async Task<Response<string>> UpdateMaterial(UpdateMaterialDto update)
    {
        return await service.UpdateMaterialAsync(update);
    }

    [HttpDelete("MaterialId:int")]
    public async Task<Response<bool>> DeleteMaterial(int MaterialId)
    {
        return await service.DeleteMaterialAsync(MaterialId);

}}
