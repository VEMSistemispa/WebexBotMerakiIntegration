using MerakiWebexBotIntegration.Dto;

namespace MerakiWebexBotIntegration.Services.Interfaces
{
    public interface ILicencesHttpService
    {
        public Task<LicenceDto> GetLicencesAsync(string organizationId);
    }
}