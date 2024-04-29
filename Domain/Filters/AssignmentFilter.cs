namespace Domain.Filters;

public class AssignmentFilter:PaginationFilter
{
    public DateTime DueDate { get; set; }
}
