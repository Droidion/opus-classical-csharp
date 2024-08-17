namespace OpusClassical.Services;

public class ColorThemeService
{
    public const string ColorThemeKey = "color-theme";
    private bool _isDarkTheme;

    public bool IsDarkTheme
    {
        get => _isDarkTheme;
        set
        {
            if (_isDarkTheme != value)
            {
                _isDarkTheme = value;
                NotifyThemeChanged();
            }
        }
    }

    public void ToggleTheme()
    {
        IsDarkTheme = !IsDarkTheme;
    }

    public event Action OnThemeChanged;

    private void NotifyThemeChanged()
    {
        OnThemeChanged?.Invoke();
    }
}