using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using NetAspireTest.Client.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<WeatherHttpClient>(x => x.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

await builder.Build().RunAsync();
