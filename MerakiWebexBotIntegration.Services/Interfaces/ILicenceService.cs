using MerakiWebexBotIntegration.Dto;

namespace MerakiWebexBotIntegration.Services.Interfaces
{
    public interface ILicenceService
    {
        public Task<LicenceDto> GetLicenceAsync(string organizationId);
        public string GetLicenceExpirationMessage(string expirationDateString);
    }
}