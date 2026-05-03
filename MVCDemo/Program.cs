using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHealthChecks()
    .AddCheck("Foo Service", () =>
    {
        // Do any Checks
        // ...
        return HealthCheckResult.Healthy("The check of the foo service did not work well.");
    }, new[] { "services" })

    .AddCheck("Bar Service", () =>
        HealthCheckResult.Healthy("The check of the bar service worked."), new[] { "services" })

    .AddCheck("Database Service", () =>
        HealthCheckResult.Degraded("The check of the database worked."), new[] { "database", "sql" });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapHealthChecks("/health", new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
