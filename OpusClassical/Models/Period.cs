using System.ComponentModel.DataAnnotations;

namespace OpusClassical.Models;

public class Period
{
    public int Id { get; init; }
    [MaxLength(50)] public string Name { get; init; } = string.Empty;
    public int? YearStart { get; init; }
    public int? YearEnd { get; init; }
    [MaxLength(50)] public string Slug { get; init; } = string.Empty;
}