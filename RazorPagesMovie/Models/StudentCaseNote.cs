using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models;

public class StudentCaseNote
{
    public int StudentCaseNoteId { get; set; }

    [Required]
    public int StudentCaseId { get; set; }

    [Required]
    public int PrescriberId { get; set; }

    public string NoteText { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    public StudentCase? StudentCase { get; set; }
    public Prescriber? Prescriber { get; set; }
}