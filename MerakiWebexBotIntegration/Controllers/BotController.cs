using MerakiWebexBotIntegration.Dto;
using MerakiWebexBotIntegration.Services.Interfaces;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MerakiWebexBotIntegration.Clients.Interfaces;

namespace MerakiWebexBotIntegration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BotController : Controller
    {
        private readonly IBotService _botService;
        private readonly IMessageService _messageService;
        private readonly IAttachmentActionService _attachmentActionService;
        private readonly ICardService _cardService;
        private readonly IWebexClient _webexClient;
        public BotController(IBotService botService, IAttachmentActionService attachmentActionService, ICardService cardService, IMessageService messageService, IWebexClient webexClient)
        {
            _botService = botService;
            _messageService = messageService;
            _attachmentActionService = attachmentActionService;
            _cardService = cardService;
            _webexClient = webexClient;
        }
        [HttpPost]
        public async Task<HttpResponseMessage> ReplyToUser(JsonElement webhookBody)
        {
            var webhookBodyDto = JsonSerializer.Deserialize<WebhookBodyDto>(webhookBody);
            var attachmentDetails = await _attachmentActionService.GetDetailsAsync(webhookBodyDto.Data.Id);
            var response = await _botService.ReplyToCardAsync(attachmentDetails.Inputs.Command);
            var message = new MessageRequestDto
            {
                ToPersonId = webhookBodyDto.Data.PersonId,
                Text = response
            };
            return await _messageService.SendMessageAsync(message);
        }


        [HttpPost]
        [Route("card")]
        public async Task<HttpResponseMessage> PostCard(JsonElement webhookBody)
        {
            var webhookBodyDto = JsonSerializer.Deserialize<WebhookBodyDto>(webhookBody);
            await _webexClient.SendMessageAsync(webhookBodyDto.Data.Id + " \n" + webhookBodyDto.Data.PersonId);
            return await _botService.ReplyToMessageAsync(webhookBodyDto.Data.Id, webhookBodyDto.Data.PersonId);
        }
    }
}