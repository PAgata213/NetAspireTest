using NetAspireTest.Shared.OpenWeather;

namespace NetAspireTest.Shared;

public record WeatherForecast(DateOnly Date, double TemperatureC, string? Summary)
{
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

  public static WeatherForecast GetFromOpenWeather(OpenWeatherData owData)
    => new(DateOnly.FromDateTime(DateTime.Now), owData.Main.Temp, owData.Weather.FirstOrDefault()?.Description ?? "");
}
