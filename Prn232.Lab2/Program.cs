using Prn232.Lab2;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapOpenApi();

app.UseHttpsRedirection();

app.Run();
