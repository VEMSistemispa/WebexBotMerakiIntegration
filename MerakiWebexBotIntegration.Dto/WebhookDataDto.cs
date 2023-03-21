using System.Text.Json.Serialization;

namespace MerakiWebexBotIntegration.Dto
{
    public class WebhookDataDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }
        [JsonPropertyName("roomId")]
        public string RoomId { get; set; }
        [JsonPropertyName("personId")]
        public string PersonId { get; set; }
        [JsonPropertyName("created")]
        public string Created { get; set; }
    }
}