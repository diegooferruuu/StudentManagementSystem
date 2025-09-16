using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace StudentManagementSystem.Models;

public class Student
{
    
    [Key]
    [Required(ErrorMessage = "Student ID is required")]
    [StringLength(8, MinimumLength = 6, ErrorMessage = "ID must be 6 to 8 characters long")]
    [RegularExpression(@"^[0-9]{6,8}$", ErrorMessage = "Numbers only (6–8 digits)")]
    public string StudentId { get; set; } = string.Empty; 

    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, ErrorMessage = "First name can't be longer than 50 characters")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, ErrorMessage = "Last name can't be longer than 50 characters")]
    public string LastName { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Date of birth is required")]
    public DateTime DateOfBirth { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(50, ErrorMessage = "Email can't be longer than 50 characters")]
    public string Email { get; set; } = string.Empty;

    [Phone(ErrorMessage = "Invalid phone number")]
    [StringLength(8, ErrorMessage = "Phone number can't have more than 8 digits")]
    public string? Phone { get; set; }
    
    public List<Score> Scores { get; set; } = new();
}