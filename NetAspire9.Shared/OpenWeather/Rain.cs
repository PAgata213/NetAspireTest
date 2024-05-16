using Newtonsoft.Json;

namespace NetAspire9.Shared.OpenWeather;

public record Rain([property: JsonProperty("1h")] double _1h);
