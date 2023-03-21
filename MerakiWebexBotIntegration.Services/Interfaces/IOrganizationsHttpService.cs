using MerakiWebexBotIntegration.Dto;

namespace MerakiWebexBotIntegration.Services.Interfaces
{
    public interface IOrganizationsHttpService
    {
        public Task<List<OrganizationDto>> GetOrganizationsAsync();
    }
}