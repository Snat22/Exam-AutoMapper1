using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
        Database.EnsureCreated();
        Database.EnsureDeleted();
    }

    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Submission> Submissions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
