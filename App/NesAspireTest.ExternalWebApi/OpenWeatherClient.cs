using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

using NetAspireTest.Shared;
using NetAspireTest.Shared.OpenWeather;

using Newtonsoft.Json;

namespace NesAspireTest.ExternalWebApi;

public static class OpenWeatherClient
{
  public static WebApplication RegisterWebApi(this WebApplication app)
  {
    app.MapGet("/openweather", GetOpenWeatherDataAsync)
      .WithName("GetOpenWeather")
      .WithOpenApi();
    app.MapGet("/openweather/{city}", GetOpenWeatherDataForCityAsync)
      .WithName("GetOpenWeatherForCity")
      .WithOpenApi();
    return app;
  }
  
  public static async Task<OpenWeatherData?> GetOpenWeatherDataAsync(HttpClient httpClient)
  {
    var response = await httpClient.GetAsync("https://api.openweathermap.org/data/2.5/weather?lat=51.083001&lon=16.959394&units=metric&appid=bec3d8f42b282c9a6651249021d1e94a");
    response.EnsureSuccessStatusCode();
    var responseString = await response.Content.ReadAsStringAsync();
    return JsonConvert.DeserializeObject<OpenWeatherData>(responseString);
  }

  public static async Task<OpenWeatherData?> GetOpenWeatherDataForCityAsync(HttpClient httpClient, string city)
  {
    var response = await httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID=bec3d8f42b282c9a6651249021d1e94a");
    response.EnsureSuccessStatusCode();
    var responseString = await response.Content.ReadAsStringAsync();
    return JsonConvert.DeserializeObject<OpenWeatherData>(responseString);
  }
}
