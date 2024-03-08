using System.Net.Http.Json;
using NetAspireTest.Shared;

namespace NetAspireTest.Client.Client;

public class WeatherHttpClient
{
	private readonly HttpClient _httpClient;

	public WeatherHttpClient(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<WeatherForecast[]> GetWeatherForecastsAsync()
	{
		var result = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
		return result ?? Array.Empty<WeatherForecast>();
	}
}

