using Microsoft.Extensions.FileProviders;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Serve static files from the root directory (for files directly in ContentRootPath)
var options = new DefaultFilesOptions();
options.FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "static"));
app.UseDefaultFiles(options);

// Serve static files from the "static" directory with a "/static" URL prefix
app.UseStaticFiles(new StaticFileOptions {
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "static")),
    RequestPath = "",
    OnPrepareResponse = ctx => {
        Console.WriteLine($"Serving static file: {ctx.Context.Request.Path}");
    }
});

// API endpoint example
app.MapGet("/student", static () => {
    Console.WriteLine("API endpoint for /student was called");
    return new {
        Id = 1,
        Name = "John Doe",
        Age = 20,
        Major = "Computer Science",
        skills = new[] { "C#", "ASP.NET Core", "Blazor" }
    };
});
app.Run();
