namespace MerakiWebexBotIntegration.Services.Interfaces
{
    public interface ICardService
    {
        public Task<HttpResponseMessage> PostCard(string roomId);
    }
}