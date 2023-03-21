using System.Text.Json.Serialization;

namespace MerakiWebexBotIntegration.Dto
{
    public class MessageRequestDto
    {
        [JsonPropertyName("attachments")]
        public List<AttachmentDto> Attachments { get; set; }
        [JsonPropertyName("toPersonId")]
        public string ToPersonId { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}