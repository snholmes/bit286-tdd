using LuckySpin.Repositories;
using LuckySpin.Services;

var builder = WebApplication.CreateBuilder(args);

//Enable MVC and DIJ Services for this application
builder.Services.AddMvc();
builder.Services.AddSingleton<ISpinRepository, SpinRepository>();
            //TODO: register the SpinService class with a type of ISpinService
builder.Services.AddTransient<ISpinService, SpinService>();
var app = builder.Build();


/* Middleware in the HTTP Request Pipeline
 */
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{luck:int?}",
    defaults: new
    {
        controller = "Spinner",
        action = "Index"
    });

app.Run();