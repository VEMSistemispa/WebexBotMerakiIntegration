using MerakiWebexBotIntegration.Dto;

namespace MerakiWebexBotIntegration.Services.Interfaces
{
    public interface IAttachmentActionService
    {
        public Task<AttachmentActionDto> GetDetailsAsync(string id);
    }
}