using System.Text.Json.Serialization;

namespace MerakiWebexBotIntegration.Dto
{
    public class AttachmentDto
    {
        [JsonPropertyName("contentType")]
        public string ContentType { get; set; }
        [JsonPropertyName("content")]
        public ContentDto Content { get; set; }
    }
}