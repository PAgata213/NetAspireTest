using NetAspireTest.Shared;
using NetAspireTest.Shared.OpenWeather;

namespace NetAspireTest;

public static class WeatherForecastWebApi
{
  public static void RegisterWebApi(this WebApplication app)
  {
    app.MapGet("/weatherforecast", GetWeatherForecast)
    .WithName("GetWeatherForecast")
    .WithOpenApi();

    app.MapGet("/weatherforecast/{city}", GetWeatherForecastForCity)
    .WithName("GetWeatherForecastForCity")
    .WithOpenApi();
  }

  public static async Task<WeatherForecast?> GetWeatherForecast(HttpClient httpClient)
  {
    var response = await httpClient.GetAsync("http://ExternalWeatherApi/openweather");
    response.EnsureSuccessStatusCode();
    var openWeatherData = await response.Content.ReadFromJsonAsync<OpenWeatherData>();
    return openWeatherData is not null ? WeatherForecast.GetFromOpenWeather(openWeatherData!) : null;
  }

  public static async Task<WeatherForecast?> GetWeatherForecastForCity(HttpClient httpClient, string city)
  {
    var response = await httpClient.GetAsync($"http://ExternalWeatherApi/openweather/{city}");
    response.EnsureSuccessStatusCode();
    var openWeatherData = await response.Content.ReadFromJsonAsync<OpenWeatherData>();
    return openWeatherData is not null ? WeatherForecast.GetFromOpenWeather(openWeatherData!) : null;
  }
}
