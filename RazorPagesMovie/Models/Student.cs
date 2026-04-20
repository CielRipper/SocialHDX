using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models;

public class Student
{
    public int StudentId { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string StudentNumber { get; set; } = string.Empty;

    [StringLength(20)]
    public string Status { get; set; } = string.Empty;
}