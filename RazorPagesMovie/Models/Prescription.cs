using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models;

public class Prescription
{
    public int PrescriptionId { get; set; }

    [Required]
    public int StudentId { get; set; }

    [Required]
    public int PrescriberId { get; set; }

    [Required]
    public int CampusEventId { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime DateAssigned { get; set; }

    public string Reason { get; set; } = string.Empty;

    [StringLength(20)]
    public string Status { get; set; } = string.Empty;

    public bool AttendanceConfirmed { get; set; }

    public bool ReminderSent { get; set; }

    public Student? Student { get; set; }
    public Prescriber? Prescriber { get; set; }
    public CampusEvent? CampusEvent { get; set; }
}