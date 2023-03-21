using MerakiWebexBotIntegration.Dto;
using MerakiWebexBotIntegration.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MerakiWebexBotIntegration.Services.Implementation
{
    public class AttachmentActionHttpService : IAttachmentActionHttpService
    {
        private const string _baseUrl = "https://webexapis.com/v1/attachment/actions";
        private string _token = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Webex")["BotAccessToken"];
        public async Task<AttachmentActionDto> GetDetailsAsync(string id)
        {
            var client = new HttpClient();
            var url = $"{_baseUrl}/{id}";
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await client.SendAsync(request);
            var attachmentAction = JsonSerializer.Deserialize<AttachmentActionDto>(await response.Content.ReadAsStreamAsync());
            return attachmentAction;
        }
    }
}