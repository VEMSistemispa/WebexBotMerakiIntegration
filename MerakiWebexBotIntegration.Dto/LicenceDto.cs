using System.Text.Json.Serialization;

namespace MerakiWebexBotIntegration.Dto
{
    public class LicenceDto
    {
        [JsonPropertyName("expirationDate")]
        public string ExpirationDate { get; set;}
    }
}