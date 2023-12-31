using Microsoft.EntityFrameworkCore;
using RazorPagesCurrency.Data;
using RazorPagesCurrency.Models;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorPagesCurrencyContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesCurrencyContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesCurrencyContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});

app.UseAuthorization();

app.Run();
