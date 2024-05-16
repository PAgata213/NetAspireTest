var builder = DistributedApplication.CreateBuilder(args);

var openWeatherApi = builder.AddProject<Projects.NetAspire9_ExternalWebApi>("openWeatherApi");

builder.AddProject<Projects.NetAspire9>("mainServer")
  .WithReference(openWeatherApi);

builder.Build().Run();
