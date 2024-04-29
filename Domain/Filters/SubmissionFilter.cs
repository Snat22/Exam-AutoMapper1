namespace Domain.Filters;

public class SubmissionFilter:PaginationFilter
{
    public string? Content { get; set; }
    public DateTime SubmissionDate { get; set; }
}
