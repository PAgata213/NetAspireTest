using NetAspireTest.Shared.OpenWeather;
using Newtonsoft.Json;

namespace NetAspireTest.ExternalWebApi;

public static class OpenWeatherClient
{
  private const string _openWeatherApiKey = "";
  public static WebApplication RegisterWebApi(this WebApplication app)
  {
    app.MapGet("/openweather", GetOpenWeatherDataAsync)
      .WithName("GetOpenWeather")
      .WithOpenApi()
      .CacheOutput(x => x.Expire(TimeSpan.FromSeconds(10)));
    app.MapGet("/openweather/{city}", GetOpenWeatherDataForCityAsync)
      .WithName("GetOpenWeatherForCity")
      .WithOpenApi()
      .CacheOutput(x => x.Expire(TimeSpan.FromSeconds(10)));
    return app;
  }
  
  public static async Task<OpenWeatherData?> GetOpenWeatherDataAsync(HttpClient httpClient)
  {
    var response = await httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat=51.083001&lon=16.959394&units=metric&appid={_openWeatherApiKey}");
    response.EnsureSuccessStatusCode();
    var responseString = await response.Content.ReadAsStringAsync();
    return JsonConvert.DeserializeObject<OpenWeatherData>(responseString);
  }

  public static async Task<OpenWeatherData?> GetOpenWeatherDataForCityAsync(HttpClient httpClient, string city)
  {
    var response = await httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={_openWeatherApiKey}");
    response.EnsureSuccessStatusCode();
    var responseString = await response.Content.ReadAsStringAsync();
    return JsonConvert.DeserializeObject<OpenWeatherData>(responseString);
  }
}
