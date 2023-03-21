using MerakiWebexBotIntegration.Clients.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MerakiWebexBotIntegration.Clients.Implementation
{
    public class WebexClient : IWebexClient
    {
        private readonly string _url = ""; //insert the incoming webhook url here
        public async Task<HttpResponseMessage> SendMessageAsync(string logMessage)
        {
            var httpClient = new HttpClient();
            var obj = new
            {
                markdown = logMessage
            };
            using var request = new HttpRequestMessage(new HttpMethod("POST"), _url)
            {
                Content = new StringContent(JsonSerializer.Serialize(obj))
            };
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var response = await httpClient.SendAsync(request);
            return response;
        }
    }
}
