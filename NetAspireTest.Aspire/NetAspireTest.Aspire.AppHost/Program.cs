var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.NetAspireTest>("netaspiretest");

builder.Build().Run();
