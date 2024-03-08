using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using NetAspireTest.Client.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<WeatherHttpClient>(x => x.BaseAddress = new Uri("http://localhost:5279"));

await builder.Build().RunAsync();
