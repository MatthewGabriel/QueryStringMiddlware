using Newtonsoft.Json;

namespace QueryMiddleware.Settings
{
    public class MessageSettings
    {
        [JsonProperty("foundMessage")]
        public string FoundMessage { get; set; }

        [JsonProperty("notFoundMessage")]
        public string NotFoundMessage { get; set; }
    }
}
