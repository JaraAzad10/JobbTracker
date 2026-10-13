using JobbTracker.Services;

var builder = WebApplication.CreateBuilder(args);

//Registrerer MVC-tjenestene (controllers + views)
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IJobApplicationService, InMemoryJobApplicationService>();

var app = builder.Build();

app.UseStaticFiles(); //gjør at filer i wwwroot (CSS, bilder) kan lastes

//standard rute: /Controller/Action/id
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
