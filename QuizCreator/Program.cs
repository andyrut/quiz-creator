using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuizCreator.Models.Database;

WebApplication? app = null;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    string connString = builder.Configuration.GetConnectionString("QUIZ_CREATOR_DB") ?? string.Empty;
    builder.Services.AddDbContext<QuizDbContext>(options => options.UseSqlServer(connString));

    builder.Logging.AddAzureWebAppDiagnostics();
    builder.Logging.AddConsole();

    app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex)
{
    app?.Logger.LogCritical(ex, "Error in Program start");
    throw;
}
