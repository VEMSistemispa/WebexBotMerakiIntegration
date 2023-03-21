namespace MerakiWebexBotIntegration.Models
{
    public class MessageEventDto
    {
        public string roomId { get; set; }
        public string roomType { get; set; }
        public string personId { get; set; }
        public string personEmail { get; set; }
        public string mentionedPeople { get; set; }
        public string hasFiles { get; set; }
    }
}