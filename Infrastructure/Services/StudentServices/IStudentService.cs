using Domain.DTOs.StudentDto;
using Domain.Responses;

namespace Infrastructure.Services.StudentServices;

public interface IStudentService
{
    public Task<Response<List<GetStudentDto>>> GetStudentsAsync();
    public Task<Response<GetStudentDto>> GetStudentByIdAsync(int id);
    public Task<Response<string>> AddStudentAsync(AddStudentDto add);
    public Task<Response<string>> UpdateStudentAsync(UpdateStudentDto update);
    public Task<Response<bool>> DeleteStudentAsync(int id);
}
