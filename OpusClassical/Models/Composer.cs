namespace OpusClassical.Models;

public class Composer
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int? YearBorn { get; init; }
    public int? YearDied { get; init; }
    public int PeriodId { get; init; }
    public string Slug { get; init; }
    public string? WikipediaLink { get; init; }
    public string? ImslpLink { get; init; }
    public bool Enabled { get; init; }
    public string Countries { get; init; }
}