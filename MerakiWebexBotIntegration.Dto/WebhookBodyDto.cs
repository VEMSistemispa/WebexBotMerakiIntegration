using System.Text.Json.Serialization;

namespace MerakiWebexBotIntegration.Dto
{
    public class WebhookBodyDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("resource")]
        public string Resource { get; set; }
        [JsonPropertyName("event")]
        public string Event { get; set; }
        [JsonPropertyName("orgId")]
        public string OrgId { get; set; }
        [JsonPropertyName("appId")]
        public string AppId { get; set; }
        [JsonPropertyName("ownedBy")]
        public string OwnedBy { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("actorId")]
        public string ActorId { get; set; }
        [JsonPropertyName("data")]
        public WebhookDataDto Data { get; set; }
    }
}