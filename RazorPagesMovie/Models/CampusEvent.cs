using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models;

public class CampusEvent
{
    public int CampusEventId { get; set; }

    [Required]
    [StringLength(150)]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime EventDate { get; set; }

    [DataType(DataType.Time)]
    public DateTime EventTime { get; set; }

    [StringLength(150)]
    public string Location { get; set; } = string.Empty;

    [StringLength(50)]
    public string Category { get; set; } = string.Empty;

    [StringLength(255)]
    public string SourceLink { get; set; } = string.Empty;
}