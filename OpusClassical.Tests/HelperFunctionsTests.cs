using OpusClassical.Helpers;

namespace OpusClassical.Tests;

public class HelperFunctionsTests
{
    [Theory]
    [InlineData(1720, null, "1720–")]
    [InlineData(1720, 1795, "1720–95")]
    [InlineData(1720, 1805, "1720–1805")]
    [InlineData(null, 1805, "1805")]
    [InlineData(null, null, "")]
    [InlineData(10000, 20000, "")]
    [InlineData(-100, 200, "200")]
    public void FormatYearsRangeString_ValidInput_ReturnsFormattedString(int? startYear, int? finishYear,
        string expected)
    {
        var result = HelperFunctions.FormatYearsRangeString(startYear, finishYear);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, "")]
    [InlineData(3, "3m")]
    [InlineData(60, "1h")]
    [InlineData(125, "2h 5m")]
    [InlineData(-60, "")]
    [InlineData(null, "")]
    public void FormatWorkLength_ValidInput_ReturnsFormattedString(int? lengthInMinutes, string expected)
    {
        var result = HelperFunctions.FormatWorkLength(lengthInMinutes);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("BWV", 12, "p", "BWV 12p")]
    [InlineData("BWV", 12, null, "BWV 12")]
    [InlineData("BWV", null, "p", "")]
    [InlineData(null, 12, "p", "")]
    [InlineData("", 12, "p", "")]
    public void FormatCatalogueName_ValidInput_ReturnsFormattedString(string catalogueName, int? catalogueNumber,
        string cataloguePostfix, string expected)
    {
        var result = HelperFunctions.FormatCatalogueName(catalogueName, catalogueNumber, cataloguePostfix);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("Symphony", 9, "Great", "Symphony No. 9 Great")]
    [InlineData("Symphony", 9, null, "Symphony No. 9")]
    [InlineData("Symphony", null, "Great", "Symphony Great")]
    [InlineData("Symphony", null, null, "Symphony")]
    [InlineData(null, 9, "Great", "")]
    public void FormatWorkName_ValidInput_ReturnsFormattedString(string workTitle, int? workNo, string workNickname,
        string expected)
    {
        var result = HelperFunctions.FormatWorkName(workTitle, workNo, workNickname);
        Assert.Equal(expected, result);
    }
}