using MerakiWebexBotIntegration.Dto;
using MerakiWebexBotIntegration.Services.Interfaces;

namespace MerakiWebexBotIntegration.Services.Implementation
{
    public class OrganizationsService : IOrganizationsService
    {
        private readonly IOrganizationsHttpService _organizationsHttpService;
        public OrganizationsService(IOrganizationsHttpService organizationsHttpService)
        {
            _organizationsHttpService = organizationsHttpService;
        }
        public async Task<List<OrganizationDto>> GetOrganizationsAsync()
        {
            return await _organizationsHttpService.GetOrganizationsAsync();
        }
        public async Task<List<OrganizationDto>> GetOrganizationsAsync(string text)
        {
            if (text == null || text.Length < 3)
            {
                return new List<OrganizationDto>();
            }
            var organizations = await GetOrganizationsAsync();
            return organizations.Where(organization => organization.Name.Trim().Contains(text.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}