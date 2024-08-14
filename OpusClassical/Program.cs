using OpusClassical.Components;
using OpusClassical.Models;
using OpusClassical.Repositories;
using Supabase;

var envConfig = new EnvironmentConfig();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(envConfig);
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<PeriodRepository>();
builder.Services.AddScoped<ComposerRepository>();
builder.Services.AddScoped<WorkRepository>();

var supabase = new Client(envConfig.SupabaseUrl, envConfig.SupabaseKey, new SupabaseOptions
{
    AutoRefreshToken = true
});

builder.Services.AddSingleton(supabase);

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

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();