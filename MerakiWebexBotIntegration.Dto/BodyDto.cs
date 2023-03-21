using System.Text.Json.Serialization;

namespace MerakiWebexBotIntegration.Dto
{
    public class BodyDto
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }
        [JsonPropertyName("wrap")]
        public bool Wrap { get; set; }
        [JsonPropertyName("size")]
        public string? Size { get; set; }
        [JsonPropertyName("weight")]
        public string? Weight { get; set; }
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("horizontalAlignment")]
        public string? HorizontalAlignment { get; set; }
        [JsonPropertyName("color")]
        public string? Color { get; set; }
        [JsonPropertyName("separator")]
        public bool Separator { get; set;}
        [JsonPropertyName("actions")]
        public List<ActionDto>? Actions { get; set; }
        [JsonPropertyName("items")]
        public List<BodyDto>? Items { get; set; }
        [JsonPropertyName("style")]
        public string? Style { get; set; }
        [JsonPropertyName("bleed")]
        public bool Bleed { get; set; }
        [JsonPropertyName("columns")]
        public List<BodyDto> Columns { get; set; }
        [JsonPropertyName("width")]
        public string? Width { get; set; }
    }
}