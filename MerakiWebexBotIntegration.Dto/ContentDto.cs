using System.Text.Json.Serialization;

namespace MerakiWebexBotIntegration.Dto
{
    public class ContentDto
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("$schema")]
        public string Schema { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
        [JsonPropertyName("body")]
        public List<BodyDto> Body { get; set; }
    }
}