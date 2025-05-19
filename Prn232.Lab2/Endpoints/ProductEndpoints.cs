//using System;
//using Carter;

//namespace Prn232.Lab2.Endpoints;

//public class ProductEndpoints : ICarterModule
//{
//    public void MapEndpoints(IEndpointRouteBuilder app)
//    {
//        app.MapGet("/products", async (Lab2DbContext context) =>
//        {
//            return await context.Products.ToListAsync();
//        });
//    }
//}
