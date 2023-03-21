using MerakiWebexBotIntegration.Dto;

namespace MerakiWebexBotIntegration.Services.Interfaces
{
    public interface IAttachmentActionHttpService
    {
        public Task<AttachmentActionDto> GetDetailsAsync(string id);
    }
}