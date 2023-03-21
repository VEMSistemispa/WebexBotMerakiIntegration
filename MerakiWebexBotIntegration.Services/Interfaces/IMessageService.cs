using MerakiWebexBotIntegration.Dto;

namespace MerakiWebexBotIntegration.Services.Interfaces
{
    public interface IMessageService
    {
        public Task<HttpResponseMessage> SendMessageAsync(MessageRequestDto requestDto);
    }
}