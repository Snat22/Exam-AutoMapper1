using Domain.Models;

namespace Domain.DTOs.CourseDtos;

public class GetCourseWithMaterialsDto
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }

    public List<string> Material { get; set; }

}
