var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/om", () => "Hei på deg!");

app.Run();
