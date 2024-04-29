namespace Domain.Filters;

public class CourseFilter:PaginationFilter
{
    public string Titile { get; set; }
    public string Instructor { get; set; }
}
