using Moviely.FrontEnd.ApplicationState;
using Moviely.FrontEnd.Components;
using Moviely.FrontEnd.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<AppState>();
builder.Services.AddHttpClient();
builder.Services.AddScoped(sp =>
{
    // Get the base address from configuration (recommended)
    var baseAddress = sp.GetRequiredService<IConfiguration>().GetValue<string>("BaseAddress");

    // Validate base address (optional, but good practice)
    if (string.IsNullOrEmpty(baseAddress))
    {
        throw new ArgumentException("BaseAddress configuration is missing.");
    }

    // Create the HttpClient instance with the validated base address
    return new HttpClient { BaseAddress = new Uri(baseAddress) };
}); 
builder.Services.AddScoped<IMovieService, MovieService>();



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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
