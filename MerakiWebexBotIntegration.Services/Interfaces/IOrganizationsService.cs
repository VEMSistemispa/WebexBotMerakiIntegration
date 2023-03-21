using MerakiWebexBotIntegration.Dto;

namespace MerakiWebexBotIntegration.Services.Interfaces
{
    public interface IOrganizationsService
    {
        public Task<List<OrganizationDto>> GetOrganizationsAsync();
        public Task<List<OrganizationDto>> GetOrganizationsAsync(string text);
    }
}