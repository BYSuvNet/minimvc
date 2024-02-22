using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var log = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("log.txt",
        rollingInterval: RollingInterval.Day,
        rollOnFileSizeLimit: true)
    .CreateLogger();

builder.Logging.ClearProviders();
// builder.Logging.AddConsole();
builder.Logging.AddSerilog(log);

var app = builder.Build();

//Exempel på att vi kan ha vanliga api-endpoints också fastän vi använder MVC:
app.MapPost("/api/sum", (int a, int b) => a + b);

//Denna metod ser till så att 
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
