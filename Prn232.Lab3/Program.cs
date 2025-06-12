using Lab3.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddOpenApi();
// Register the Infrastructure Layer DI to the service collection
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection")!);

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
