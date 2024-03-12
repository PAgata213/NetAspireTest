var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("rediscache");

var externalApi = builder.AddProject<Projects.NetAspireTest_ExternalWebApi>("ExternalWeatherApi")
  .WithReference(cache);

builder.AddProject<Projects.NetAspireTest>("HostedMainApp")
  .WithReference(externalApi);

builder.Build().Run();
