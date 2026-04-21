using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models;

public class StudentCase
{
    public int StudentCaseId { get; set; }

    [Required]
    public int StudentId { get; set; }

    [Required]
    public int PrescriberId { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime OpenedDate { get; set; }

    public string CaseReason { get; set; } = string.Empty;

    [StringLength(20)]
    public string CaseStatus { get; set; } = string.Empty;

    public Student? Student { get; set; }
    public Prescriber? Prescriber { get; set; }
    public List<StudentCaseNote> StudentCaseNotes { get; set; } = new();
}