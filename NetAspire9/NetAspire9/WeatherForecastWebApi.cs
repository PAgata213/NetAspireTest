using NetAspire9.Shared.OpenWeather;
using NetAspire9.Shared;

namespace NetAspire9;
public static class WeatherForecastWebApi
{
  public static void RegisterWebApi(this WebApplication app)
  {
    app.MapGet("/weatherforecast", GetWeatherForecast)
    .WithName("GetWeatherForecast")
    .WithOpenApi()
    .CacheOutput(builder => builder.Expire(TimeSpan.FromSeconds(15)));

    app.MapGet("/weatherforecast/{city}", GetWeatherForecastForCity)
    .WithName("GetWeatherForecastForCity")
    .WithOpenApi()
    .CacheOutput(builder => builder.Expire(TimeSpan.FromSeconds(15)));
  }

  public static async Task<WeatherForecast?> GetWeatherForecast(HttpClient httpClient)
  {
    var response = await httpClient.GetAsync("http://openWeatherApi/openweather");
    response.EnsureSuccessStatusCode();
    var openWeatherData = await response.Content.ReadFromJsonAsync<OpenWeatherData>();
    return openWeatherData is not null ? WeatherForecast.GetFromOpenWeather(openWeatherData!) : null;
  }

  public static async Task<WeatherForecast?> GetWeatherForecastForCity(HttpClient httpClient, string city)
  {
    var response = await httpClient.GetAsync($"http://openWeatherApi/openweather/{city}");
    response.EnsureSuccessStatusCode();
    var openWeatherData = await response.Content.ReadFromJsonAsync<OpenWeatherData>();
    return openWeatherData is not null ? WeatherForecast.GetFromOpenWeather(openWeatherData!) : null;
  }
}
