using Domain.DTOs.AssignmentDtos;
using Domain.DTOs.StudentDto;
using Domain.DTOs.SubmissionDto;
using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services.SubmissionServices;

public interface ISubmissionService
{
    public Task<Response<string>>SubmitAssignment(AddStudentDto student, AddAssignmentDto assignment);
    public Task<Response<GetSubmissionDto>> GetSubmissionsForAssignment(int assignmentId);
    public Task<Response<GetSubmissionDto>> GetSubmissionById(int id);
}
