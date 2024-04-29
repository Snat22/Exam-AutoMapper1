namespace Domain.Models;

public class Assignment:BaseEntity
{
    public int CourseId { get; set; }
    public Course? Course { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}
