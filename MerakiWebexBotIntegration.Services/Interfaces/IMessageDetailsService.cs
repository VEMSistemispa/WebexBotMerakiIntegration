using MerakiWebexBotIntegration.Dto;

namespace MerakiWebexBotIntegration.Services.Interfaces
{
    public interface IMessageDetailsService
    {
        public Task<MessageDetailsDto> GetDetailsAsync(string messageId);
    }
}