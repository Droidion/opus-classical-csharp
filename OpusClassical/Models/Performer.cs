using System.ComponentModel.DataAnnotations;

namespace OpusClassical.Models;

public class Performer
{
    public int RecordingId { get; init; }
    [MaxLength(100)] public string? FirstName { get; init; }
    [MaxLength(100)] public string LastName { get; init; } = string.Empty;
    [MaxLength(100)] public string Instrument { get; init; } = string.Empty;
    public int? Priority { get; init; }
}