using Newtonsoft.Json;

namespace NetAspireTest.Shared.OpenWeather;

public record Rain([property: JsonProperty("1h")] double _1h);
