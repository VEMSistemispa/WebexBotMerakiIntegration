using MerakiWebexBotIntegration.Dto;
using MerakiWebexBotIntegration.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MerakiWebexBotIntegration.Services.Implementation
{
    public class MessageDetailsHttpService : IMessageDetailsHttpService
    {
        private const string _baseUrl = "https://webexapis.com/v1/messages";
        private string _token = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Webex")["BotAccessToken"];
        public async Task<MessageDetailsDto> GetDetailsAsync(string messageId)
        {
            var client = new HttpClient();
            var url = $"{_baseUrl}/{messageId}";
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await client.SendAsync(request);
            var messageDetails = JsonSerializer.Deserialize<MessageDetailsDto>(await response.Content.ReadAsStreamAsync());
            return messageDetails;
        }
    }
}