using Domain.DTOs.CourseDtos;
using Domain.Responses;

namespace Infrastructure.Services.CourseServices;

public interface ICourseService
{
    public Task<Response<List<GetCourseDto>>> GetCoursesAsync();
    public Task<Response<List<GetCourseWithMaterialsDto>>> GetCourseWithMaterialsAsync(int courseId);
    public Task<Response<GetCourseDto>> GetCourseByIdAsync(int id);
    public Task<Response<string>> AddCourseAsync(AddCourseDto add);
    public Task<Response<string>> UpdateCourseAsync(UpdateCourseDto update);
    public Task<Response<bool>> DeleteCourseAsync(int id);
}
