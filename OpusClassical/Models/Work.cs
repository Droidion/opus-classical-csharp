using System.ComponentModel.DataAnnotations;

namespace OpusClassical.Models;

public class Work
{
    public int Id { get; init; }
    [MaxLength(100)] public string Title { get; init; } = string.Empty;
    public int? YearStart { get; init; }
    public int? YearFinish { get; init; }
    public int? AverageMinutes { get; init; }
    [MaxLength(50)] public string? CatalogueName { get; init; }
    public int? CatalogueNumber { get; init; }
    [MaxLength(100)] public string? CataloguePostfix { get; init; }
    public int? No { get; init; }
    [MaxLength(100)] public string? Nickname { get; init; }
    public int ComposerId { get; init; }
    public int? Sort { get; init; }
    public int GenreId { get; init; }
    [MaxLength(100)] public string GenreName { get; init; } = string.Empty;
}