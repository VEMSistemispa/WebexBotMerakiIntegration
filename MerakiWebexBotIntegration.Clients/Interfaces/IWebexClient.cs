namespace MerakiWebexBotIntegration.Clients.Interfaces
{
    public interface IWebexClient
    {
        public Task<HttpResponseMessage> SendMessageAsync(string logMessage);
    }
}
