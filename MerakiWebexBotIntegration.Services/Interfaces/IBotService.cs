using MerakiWebexBotIntegration.Dto;
using MerakiWebexBotIntegration.Enums;

namespace MerakiWebexBotIntegration.Services.Interfaces
{
    public interface IBotService
    {
        public Task<string> ReplyToCardAsync(Command command);
        public Task<HttpResponseMessage> ReplyToMessageAsync(string messageId, string personId);
    }
}