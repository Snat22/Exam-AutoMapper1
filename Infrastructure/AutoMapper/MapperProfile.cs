using AutoMapper;
using Domain.DTOs.AssignmentDtos;
using Domain.DTOs.CourseDtos;
using Domain.DTOs.FeedbackDtos;
using Domain.DTOs.MaterialDtos;
using Domain.DTOs.StudentDto;
using Domain.DTOs.SubmissionDto;
using Domain.Models;

namespace Infrastructure.AutoMapper;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        // ASSIGNMENT
        CreateMap<Assignment,AddAssignmentDto>().ReverseMap();
        CreateMap<Assignment,GetAssignmentDto>().ReverseMap();
        CreateMap<Assignment,UpdateAssignmentDto>().ReverseMap();
        
        // COURSE   
        CreateMap<Course,AddCourseDto>().ReverseMap();
        CreateMap<Course,GetCourseDto>().ReverseMap();
        CreateMap<Course,UpdateCourseDto>().ReverseMap();

        // FEEDBACK
        CreateMap<Feedback,AddFeedbackDto>().ReverseMap();
        CreateMap<Feedback,GetFeedbackDto>().ReverseMap();
        CreateMap<Feedback,UpdateFeedbackDto>().ReverseMap();

        // MATERIAL
        CreateMap<Material,AddMaterialDto>().ReverseMap();
        CreateMap<Material,GetMaterialDto>().ReverseMap();
        CreateMap<Material,UpdateMaterialDto>().ReverseMap();

        // STUDENT
        CreateMap<Student,AddStudentDto>().ReverseMap();
        CreateMap<Student,GetStudentDto>().ReverseMap();
        CreateMap<Student,UpdateStudentDto>().ReverseMap();

        // SUBMISSION
        CreateMap<Submission,AddSubmissionDto>().ReverseMap();
        CreateMap<Submission,GetSubmissionDto>().ReverseMap();
        CreateMap<Submission,UpdateSubmissionDto>().ReverseMap();
    }
}
