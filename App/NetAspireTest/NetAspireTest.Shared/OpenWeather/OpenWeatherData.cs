namespace NetAspireTest.Shared.OpenWeather;

public record OpenWeatherData(Coord Coord, IReadOnlyList<Weather> Weather, string Base, Main Main, int Visibility, Wind Wind, Rain Rain, Clouds Clouds, int Dt, Sys Sys, int Timezone, int Id, string Name, int Cod);