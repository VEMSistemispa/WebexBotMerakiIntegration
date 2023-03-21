using MerakiWebexBotIntegration.Dto;
using MerakiWebexBotIntegration.Services.Interfaces;

namespace MerakiWebexBotIntegration.Services.Implementation
{
    public class AttachmentActionService : IAttachmentActionService
    {
        private readonly IAttachmentActionHttpService _attachmentActionHttpService;
        public AttachmentActionService(IAttachmentActionHttpService attachmentActionHttpService)
        {
            _attachmentActionHttpService = attachmentActionHttpService;
        }
        public async Task<AttachmentActionDto> GetDetailsAsync(string id)
        {
            return await _attachmentActionHttpService.GetDetailsAsync(id);
        }
    }
}