using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace OpusClassical.Services;

public class ColorThemeService(ProtectedLocalStorage protectedLocalStore, ILogger<ColorThemeService> logger)
{
    private const string ColorThemeKey = "color-theme";
    private bool _isDarkTheme;

    public bool IsDarkTheme
    {
        get => _isDarkTheme;
        private set
        {
            if (_isDarkTheme == value) return;
            _isDarkTheme = value;
            NotifyThemeChanged();
        }
    }

    public async Task ToggleTheme()
    {
        IsDarkTheme = !IsDarkTheme;
        try
        {
            await protectedLocalStore.SetAsync(ColorThemeKey, IsDarkTheme ? "dark" : "light");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error saving theme to browser local storage");
        }
    }

    public async Task RestoreChosenTheme()
    {
        try
        {
            var cachedTheme = await protectedLocalStore.GetAsync<string>(ColorThemeKey);
            if (cachedTheme.Success) IsDarkTheme = cachedTheme.Value == "dark";
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error loading theme from browser local storage");
            IsDarkTheme = false;
        }
    }

    public event Action? OnThemeChanged;

    private void NotifyThemeChanged()
    {
        OnThemeChanged?.Invoke();
    }
}