using Domain.DTOs.MaterialDtos;
using Domain.Responses;

namespace Infrastructure.Services.MaterialServices;

public interface IMaterialService
{
    public Task<Response<List<GetMaterialDto>>> GetMaterialsAsync();
    public Task<Response<GetMaterialDto>> GetMaterialByIdAsync(int id);
    // public Task<Response<>> GetMaterialForCourse();    
    public Task<Response<string>> AddMaterialAsync(AddMaterialDto add);
    public Task<Response<string>> UpdateMaterialAsync(UpdateMaterialDto update);
    public Task<Response<bool>> DeleteMaterialAsync(int id);
}
