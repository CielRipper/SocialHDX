using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models;

public class Prescriber
{
    public int PrescriberId { get; set; }

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

    [StringLength(100)]
    public string Department { get; set; } = string.Empty;

    public bool TrainedStatus { get; set; }
}