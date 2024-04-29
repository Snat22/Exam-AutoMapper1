namespace Domain.Models;

public class Course:BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Instructor { get; set; }
    public int Credits { get; set; }
}
