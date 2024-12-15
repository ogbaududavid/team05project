using team_project.Components;
using team_project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<AccountService>();
builder.Services.AddSingleton<TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Map Razor Components.
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Heroku assigns a port via the PORT environment variable.
var port = Environment.GetEnvironmentVariable("PORT") ?? "5225";
app.Urls.Add($"http://*:{port}");

app.Run();
