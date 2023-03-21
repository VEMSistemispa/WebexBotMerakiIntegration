using System.Text.Json.Serialization;

namespace MerakiWebexBotIntegration.Dto
{
    public class ActionDto
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("data")]
        public object Data { get; set; }
    }
}