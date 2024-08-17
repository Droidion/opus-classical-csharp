using System.ComponentModel.DataAnnotations;

namespace OpusClassical.Models;

public class Composer
{
    public int Id { get; init; }
    [MaxLength(100)] public string FirstName { get; init; } = string.Empty;
    [MaxLength(100)] public string LastName { get; init; } = string.Empty;
    public int? YearBorn { get; init; }
    public int? YearDied { get; init; }
    public int PeriodId { get; init; }
    [MaxLength(50)] public string Slug { get; init; } = string.Empty;
    [MaxLength(200)] public string? WikipediaLink { get; init; }
    [MaxLength(200)] public string? ImslpLink { get; init; }
    public bool Enabled { get; init; }
    [MaxLength(200)] public string Countries { get; init; } = string.Empty;
}