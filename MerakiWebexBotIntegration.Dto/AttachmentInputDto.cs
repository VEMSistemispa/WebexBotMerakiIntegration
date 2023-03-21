using MerakiWebexBotIntegration.Enums;
using System.Text.Json.Serialization;

namespace MerakiWebexBotIntegration.Dto
{
    public class AttachmentInputDto
    {
        [JsonPropertyName("command")]
        public Command Command { get; set; }
    }
}