using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .Property(s => s.StudentId)
            .ValueGeneratedNever();
        modelBuilder.Entity<Student>()
            .Property(s => s.DateOfBirth)
            .HasColumnType("timestamp");
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Score> Scores { get; set; }
}