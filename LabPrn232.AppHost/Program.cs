var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var password = builder.AddParameter("password", secret: true);
var sql = builder.AddSqlServer("sql", password);
var sqldb = sql.AddDatabase("sqldb");
var lab3db = sql.AddDatabase("lab3");

builder.AddProject<Projects.Prn231_Lab1>("prn231-lab1")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(sqldb)
    .WaitFor(sqldb);

builder.AddProject<Projects.Prn232_Lab2>("prn232-lab2")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache);

builder.AddProject<Projects.Prn232_Lab3>("prn232-lab3")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(lab3db)
    .WaitFor(lab3db);

builder.AddProject<Projects.SE171643_API>("se171643-api");

builder.Build().Run();
