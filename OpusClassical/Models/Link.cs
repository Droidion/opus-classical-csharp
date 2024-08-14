using System.ComponentModel.DataAnnotations;

namespace OpusClassical.Models;

public class Link
{
    public int RecordingId { get; init; }
    [MaxLength(100)] public string RecordingLink { get; init; } = string.Empty;
    [MaxLength(100)] public string Streamer { get; init; } = string.Empty;
    [MaxLength(10)] public string Icon { get; init; } = string.Empty;
    [MaxLength(50)] public string LinkPrefix { get; init; } = string.Empty;
}