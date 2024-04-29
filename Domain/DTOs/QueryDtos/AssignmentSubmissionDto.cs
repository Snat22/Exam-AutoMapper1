using Domain.Models;

namespace Domain.DTOs.QueryDtos;

public class AssignmentSubmissionDto
{
    public int AssignmentId { get; set; }
    public int StudentId { get; set; }
    public Assignment Assignment { get; set; }
}
