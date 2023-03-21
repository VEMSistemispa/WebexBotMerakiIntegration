using MerakiWebexBotIntegration.Services.Interfaces;
using System.Net.Http.Headers;
using MerakiWebexBotIntegration.Dto;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace MerakiWebexBotIntegration.Services.Implementation
{
    public class MessageHttpService : IMessageHttpService
    {
        private const string _url = "https://webexapis.com/v1/messages";
        private string _token = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Webex")["BotAccessToken"];
        public async Task<HttpResponseMessage> SendMessageAsync(MessageRequestDto requestDto)
        {
            var client = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Post, _url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var json = JsonSerializer.Serialize(requestDto);
            request.Content = new StringContent(json);
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var response = await client.SendAsync(request);
            return response;
        }
    }
}