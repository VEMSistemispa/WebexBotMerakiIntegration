using MerakiWebexBotIntegration.Dto;
using MerakiWebexBotIntegration.Services.Interfaces;

namespace MerakiWebexBotIntegration.Services.Implementation
{
    public class MessageService : IMessageService
    {
        private readonly IMessageHttpService _messageHttpService;
        public MessageService(IMessageHttpService messageHttpService)
        {
            _messageHttpService = messageHttpService;
        }
        public async Task<HttpResponseMessage> SendMessageAsync(MessageRequestDto requestDto)
        {
            return await _messageHttpService.SendMessageAsync(requestDto);
        }
    }
}