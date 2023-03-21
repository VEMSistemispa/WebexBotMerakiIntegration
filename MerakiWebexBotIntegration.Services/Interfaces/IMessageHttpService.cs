using MerakiWebexBotIntegration.Dto;

namespace MerakiWebexBotIntegration.Services.Interfaces
{
    public interface IMessageHttpService
    {
        public Task<HttpResponseMessage> SendMessageAsync(MessageRequestDto requestDto);
    }
}