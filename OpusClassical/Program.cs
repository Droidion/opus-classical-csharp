using OpusClassical.Components;
using OpusClassical.Models;
using OpusClassical.Repositories;
using OpusClassical.Services;
using Supabase;

var envConfig = new EnvironmentConfig();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(envConfig);
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IPeriodRepository, PeriodRepository>();
builder.Services.AddScoped<IComposerRepository, ComposerRepository>();
builder.Services.AddScoped<IWorkRepository, WorkRepository>();
builder.Services.AddScoped<IRecordingRepository, RecordingRepository>();
builder.Services.AddScoped<IPerformerRepository, PerformerRepository>();
builder.Services.AddScoped<ILinkRepository, LinkRepository>();
builder.Services.AddScoped<IComposerSearchRepository, ComposerSearchRepository>();
builder.Services.AddScoped<IComposerSearchService, ComposerSearchService>();
builder.Services.AddScoped<ColorThemeService>();

var supabase = new Client(envConfig.SupabaseUrl, envConfig.SupabaseKey, new SupabaseOptions
{
    AutoRefreshToken = true
});

builder.Services.AddSingleton(supabase);

builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();