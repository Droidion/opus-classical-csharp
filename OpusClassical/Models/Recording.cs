using System.ComponentModel.DataAnnotations;

namespace OpusClassical.Models;

public class Recording
{
    public int Id { get; init; }
    [MaxLength(100)] public string CoverName { get; init; } = string.Empty;
    public int? Length { get; init; }
    [MaxLength(100)] public string Label { get; init; } = string.Empty;
    public int WorkId { get; init; }
    public int? YearStart { get; init; }
    public int? YearFinish { get; init; }
}