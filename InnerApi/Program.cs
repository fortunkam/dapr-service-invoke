using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("/api/{fromOuter}", (string? fromOuter) => {
    Console.WriteLine("INNER API CALLED");
    return $"OK from Inner (query param = {fromOuter ?? "UNKNOWN"})";
});

app.Run();
