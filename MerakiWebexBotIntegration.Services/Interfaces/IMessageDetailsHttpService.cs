using MerakiWebexBotIntegration.Dto;

namespace MerakiWebexBotIntegration.Services.Interfaces
{
    public interface IMessageDetailsHttpService
    {
        public Task<MessageDetailsDto> GetDetailsAsync(string messageId);
    }
}
