using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NetAspire9.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddHttpClient<WeatherHttpClient>(x => x.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

await builder.Build().RunAsync();
