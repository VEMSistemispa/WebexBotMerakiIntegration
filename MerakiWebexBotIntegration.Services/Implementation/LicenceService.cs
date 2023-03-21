using MerakiWebexBotIntegration.Dto;
using MerakiWebexBotIntegration.Services.Interfaces;
using System.Globalization;

namespace MerakiWebexBotIntegration.Services.Implementation
{
    public class LicenceService : ILicenceService
    {
        private readonly ILicencesHttpService _licencesHttpService;
        private readonly IOrganizationsService _organizationsService;
        public LicenceService(ILicencesHttpService licencesHttpService, IOrganizationsService organizationsService)
        {
            _licencesHttpService = licencesHttpService;
            _organizationsService = organizationsService;
        }
        public async Task<LicenceDto> GetLicenceAsync(string organizationId)
        {
            var licence = await _licencesHttpService.GetLicencesAsync(organizationId);
            return licence;
        }
        public string GetLicenceExpirationMessage(string expirationDateString)
        {
            var expirationDate = DateTime.ParseExact(expirationDateString.Replace("UTC", string.Empty).Trim(), "MMM dd, yyyy", CultureInfo.InvariantCulture);
            var expiredMessage = $"{expirationDate.ToShortDateString()} ";
            if (expirationDate.Date < DateTime.UtcNow.Date)
            {
                expiredMessage += "(la licenza è scaduta)";
            }
            if (expirationDate.Date == DateTime.UtcNow.Date)
            {
                expiredMessage += "(la licenza scade in data odierna)";
            }
            return expiredMessage;
        }
    }
}