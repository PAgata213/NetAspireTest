using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using NetAspireTest.Client;
using NetAspireTest.Client.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<WeatherHttpClient>(x => x.BaseAddress = new Uri("https://localhost:7006"));

await builder.Build().RunAsync();
