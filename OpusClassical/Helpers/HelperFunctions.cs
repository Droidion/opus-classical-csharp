namespace OpusClassical.Helpers;

public static class HelperFunctions
{
    /// <summary>
    ///     isValidYear checks if given number is a 4 digits number, like 1234 (not -123, 123, or 12345).
    /// </summary>
    private static bool IsValidYear(int num)
    {
        return num is > 1 and < 10000;
    }

    /// <summary>
    ///     sliceYear returns slice of the full year, like 85 from 1985.
    /// </summary>
    private static string SliceYear(int year)
    {
        var yearStr = year.ToString();
        return yearStr.Length < 4 ? yearStr : yearStr.Substring(2, 2);
    }

    private static string GetCentury(int year)
    {
        return year.ToString()[..2];
    }

    /// <summary>
    ///     centuryEqual checks if two given years are of the same century, like 1320 and 1399.
    /// </summary>
    private static bool CenturyEqual(int year1, int year2)
    {
        if (!IsValidYear(year1) || !IsValidYear(year2)) return false;
        return GetCentury(year1) == GetCentury(year2);
    }

    /// <summary>
    ///     FormatYearsRangeString formats the range of two years into the string, e.g. "1720–95", or "1720–1805", or "1720–".
    ///     Start year and dash are always present.
    ///     It's supposed to be used for lifespans, meaning we always have birth, but may not have death.
    /// </summary>
    public static string FormatYearsRangeString(int? startYear, int? finishYear)
    {
        if (!startYear.HasValue && !finishYear.HasValue) return string.Empty;
        if (!IsValidYear(startYear.GetValueOrDefault()) && !IsValidYear(finishYear.GetValueOrDefault()))
            return string.Empty;
        if (startYear.HasValue && IsValidYear(startYear.Value) && !finishYear.HasValue) return $"{startYear.Value}–";
        var finishYearInt = finishYear.GetValueOrDefault();
        if (!startYear.HasValue || !IsValidYear(startYear.Value)) return finishYearInt.ToString();
        return CenturyEqual(startYear.Value, finishYearInt)
            ? $"{startYear.Value}–{SliceYear(finishYearInt)}"
            : $"{startYear.Value}–{finishYearInt}";
    }

    /// <summary>
    ///     FormatWorkLength formats minutes into a string with hours and minutes, like "2h 35m"
    /// </summary>
    public static string FormatWorkLength(int? lengthInMinutes)
    {
        if (!lengthInMinutes.HasValue) return string.Empty;
        var hours = lengthInMinutes.Value / 60;
        var minutes = lengthInMinutes.Value % 60;
        if (hours == 0 && minutes == 0) return string.Empty;
        if (hours < 0 || minutes < 0) return string.Empty;
        if (hours == 0) return $"{minutes}m";
        return minutes == 0 ? $"{hours}h" : $"{hours}h {minutes}m";
    }

    /// <summary>
    ///     FormatCatalogueName formats catalogue name of the musical work, like "BWV 12p".
    /// </summary>
    public static string FormatCatalogueName(string catalogueName, int? catalogueNumber, string cataloguePostfix)
    {
        if (string.IsNullOrWhiteSpace(catalogueName) || !catalogueNumber.HasValue) return string.Empty;
        return $"{catalogueName} {catalogueNumber.Value}{cataloguePostfix}";
    }

    /// <summary>
    ///     FormatWorkName formats music work full name, like "Symphony No. 9 Great".
    /// </summary>
    public static string FormatWorkName(string workTitle, int? workNo, string workNickname)
    {
        if (string.IsNullOrWhiteSpace(workTitle)) return string.Empty;
        var workName = workTitle;
        if (workNo.HasValue) workName = $"{workName} No. {workNo.Value}";
        if (!string.IsNullOrWhiteSpace(workNickname)) workName = $"{workName} {workNickname}";
        return workName;
    }
}