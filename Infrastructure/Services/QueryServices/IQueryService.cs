using Domain.DTOs.CourseDtos;
using Domain.DTOs.StudentDto;
using Domain.Responses;

namespace Infrastructure.Services.QueryServices;

public interface IQueryService
{
    public Task<Response<List<StudentSubmissionCountDto>>> GetStudentSubmissionCounts();
    public Task<Response<List<GetStudentDto>>> GetStudentsWithoutSubmissions(string courseName);
    public Task<Response<List<CourseMaterialCountDto>>> GetCourseMaterialCounts();

    public  Task<Response<List<GetStudentDto>>> GetStudentsWithAllTimelySubmissions();

}
