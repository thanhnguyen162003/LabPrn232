using Microsoft.EntityFrameworkCore;
using Prn231.Lab1.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Products API", Version = "v1" });
});

builder.AddSqlServerDbContext<ApplicationDbContext>("sqldb");

builder.Services.AddOpenApi();

var app = builder.Build();

// Initialize database
DatabaseInit.Initialize(app.Services);

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/products", async (ApplicationDbContext db) =>
{
    var products = await db.Products.ToListAsync();
    return products;
})
.WithName("GetProducts");

app.Run();

