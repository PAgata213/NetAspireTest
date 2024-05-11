using System.Net.Http.Json;
using NetAspireTest.Shared;

namespace NetAspireTest.Client.Client;

public class WeatherHttpClient(HttpClient _httpClient)
{
	private readonly HttpClient _httpClient = _httpClient;

  public async Task<WeatherForecast[]> GetWeatherForecastsAsync()
	{
		var result = await _httpClient.GetFromJsonAsync<WeatherForecast?>("WeatherForecast");
		return result is not null ? [result] : [];
	}
}

