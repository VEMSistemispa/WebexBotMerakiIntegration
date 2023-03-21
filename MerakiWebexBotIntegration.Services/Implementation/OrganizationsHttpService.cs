using MerakiWebexBotIntegration.Dto;
using MerakiWebexBotIntegration.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace MerakiWebexBotIntegration.Services.Implementation
{
    public class OrganizationsHttpService : IOrganizationsHttpService
    {
        protected const string HeaderApiKey = "X-Cisco-Meraki-API-Key";
        private const string _baseUrl = "https://api.meraki.com/api/v1/organizations";
        private string _apiKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Meraki")["ApiKey"];
        public async Task<List<OrganizationDto>> GetOrganizationsAsync()
        {
            var client = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl)
            {
                Headers = {{HeaderApiKey, _apiKey}}
            };
            var response = await client.SendAsync(request);
            var organizations = JsonSerializer.Deserialize<List<OrganizationDto>>(await response.Content.ReadAsStreamAsync());
            return organizations;
        }
    }
}