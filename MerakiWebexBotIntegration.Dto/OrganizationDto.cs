using System.Text.Json.Serialization;

namespace MerakiWebexBotIntegration.Dto
{
    public class OrganizationDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}