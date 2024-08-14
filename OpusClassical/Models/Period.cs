namespace OpusClassical.Models;

public class Period
{
    public int Id { get; init; }
    public string Name { get; init; }
    public int? YearStart { get; init; }
    public int? YearEnd { get; init; }
    public string Slug { get; init; }
}