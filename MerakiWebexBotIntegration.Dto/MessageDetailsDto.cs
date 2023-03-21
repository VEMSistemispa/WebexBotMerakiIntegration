using System.Text.Json.Serialization;

namespace MerakiWebexBotIntegration.Dto
{
    public class MessageDetailsDto
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
