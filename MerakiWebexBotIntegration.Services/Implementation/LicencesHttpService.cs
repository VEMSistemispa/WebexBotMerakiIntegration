using MerakiWebexBotIntegration.Dto;
using MerakiWebexBotIntegration.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace MerakiWebexBotIntegration.Services.Implementation
{
    public class LicencesHttpService : ILicencesHttpService
    {
        protected const string HeaderApiKey = "X-Cisco-Meraki-API-Key";
        private const string _baseUrl = "https://api.meraki.com/api/v1/organizations";
        private string _apiKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Meraki")["ApiKey"];
        public async Task<LicenceDto> GetLicencesAsync(string organizationId)
        {
            var client = new HttpClient();
            var url = $"{_baseUrl}/{organizationId}/licenses/overview";
            using var request = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Headers = { { HeaderApiKey, _apiKey } }
            };
            var response = await client.SendAsync(request);
            var organizationsLicences = JsonSerializer.Deserialize<LicenceDto>(await response.Content.ReadAsStreamAsync());
            return organizationsLicences;
        }
    }
}