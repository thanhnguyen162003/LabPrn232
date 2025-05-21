using Prn232.Lab2;
using Lab2.Repo;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddOpenApi();
builder.Services.AddRepositories();

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapOpenApi();

app.UseHttpsRedirection();

app.Run();
