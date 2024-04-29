using Domain.DTOs.AssignmentDtos;
using Domain.Responses;

namespace Infrastructure.Services.AssignmentServices;

public interface IAssignmentService
{
    public Task<Response<List<GetAssignmentDto>>> GetAssignmentsAsync();
    public Task<Response<GetAssignmentDto>> GetAssignmentByIdAsync(int id);
    public Task<Response<string>> AddAssignmentAsync(AddAssignmentDto add);
    public Task<Response<string>> UpdateAssignmentAsync(UpdateAssignmentDto update);
    public Task<Response<bool>> DeleteAssignmentAsync(int id);
}
