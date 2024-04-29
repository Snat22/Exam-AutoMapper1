namespace Domain.Filters;

public class StudentFilter:PaginationFilter
{
    public string? Email { get; set; }
    public DateTime EnrollmentDate { get; set; }
}
