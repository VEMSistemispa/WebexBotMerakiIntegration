using MerakiWebexBotIntegration.Dto;
using MerakiWebexBotIntegration.Services.Interfaces;

namespace MerakiWebexBotIntegration.Services.Implementation
{
    public class MessageDetailsService : IMessageDetailsService
    {
        private readonly IMessageDetailsHttpService _messageDetailsHttpService;
        public MessageDetailsService(IMessageDetailsHttpService messageDetailsHttpService)
        {
            _messageDetailsHttpService = messageDetailsHttpService;
        }
        public async Task<MessageDetailsDto> GetDetailsAsync(string messageId)
        {
            return await _messageDetailsHttpService.GetDetailsAsync(messageId);
        }
    }
}