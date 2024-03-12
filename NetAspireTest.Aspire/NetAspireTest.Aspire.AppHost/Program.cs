var builder = DistributedApplication.CreateBuilder(args);

var externalApi = builder.AddProject<Projects.NesAspireTest_ExternalWebApi>("ExternalWeatherApi");

builder.AddProject<Projects.NetAspireTest>("HostedMainApp")
  .WithReference(externalApi);

builder.Build().Run();
