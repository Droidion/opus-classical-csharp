using System.ComponentModel.DataAnnotations;

namespace OpusClassical.Models;

public class ComposerSearchResult
{
    public int Id { get; init; }
    [MaxLength(100)] public string FirstName { get; init; } = string.Empty;
    [MaxLength(100)] public string LastName { get; init; } = string.Empty;
    [MaxLength(50)] public string Slug { get; init; } = string.Empty;
}