namespace Domain.Models;

public class Student:BaseEntity 
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime EnrollmentDate { get; set; }
}
