using MerakiWebexBotIntegration.Dto;
using MerakiWebexBotIntegration.Enums;
using MerakiWebexBotIntegration.Services.Interfaces;

using System.Globalization;
using System.Text.Json;

namespace MerakiWebexBotIntegration.Services.Implementation
{
    public class BotService : IBotService
    {
        private readonly IOrganizationsService _organizationService;
        private readonly ILicenceService _licenceService;
        private readonly IMessageDetailsService _messageDetailsService;
        private readonly ICardService _cardService;
        private readonly IMessageService _messageService;
        public BotService(IOrganizationsService organizationService, ILicenceService licenceService, IMessageDetailsService messageDetailsService, ICardService cardService, IMessageService messageService)
        {
            _organizationService = organizationService;
            _licenceService = licenceService;
            _messageDetailsService = messageDetailsService;
            _cardService = cardService;
            _messageService = messageService;
        }
        public async Task<string> ReplyToCardAsync(Command command)
        {
            var response = string.Empty;
            switch (command)
            {
                case Command.ListOrganizations:
                    var organizations = await _organizationService.GetOrganizationsAsync();
                    
                    foreach (var organization in organizations)
                    {
                        response += $"Customer: {organization.Name}. Customer Id: {organization.Id}\n";
                    }

                    break;
                case Command.ListLicensens:
                    var organizationList = await _organizationService.GetOrganizationsAsync();
                    response = await GetOrganizationLicenceMessageAsync(organizationList);
                    break;
                default:
                    response = "Invalid command.";
                    break;
            }
            return response;
        }
        public async Task<HttpResponseMessage> ReplyToMessageAsync(string messageId, string personId)
        {
            var messageDetails = await _messageDetailsService.GetDetailsAsync(messageId);
            var organizations = await _organizationService.GetOrganizationsAsync(messageDetails.Text);
            if (organizations.Any())
            {
                var response = await GetOrganizationLicenceMessageAsync(organizations);
                var message = new MessageRequestDto
                {
                    ToPersonId = personId,
                    Text = response
                };
                return await _messageService.SendMessageAsync(message);
            }
            else
            {
                return await _cardService.PostCard(personId);
            }
        }
        private async Task<string> GetOrganizationLicenceMessageAsync(List<OrganizationDto> organizations)
        {
            var response = string.Empty;
            foreach (var organization in organizations)
            {
                var organizationLicense = await _licenceService.GetLicenceAsync(organization.Id);
                response += $"Customer: {organization.Name}. License expiration date: {organizationLicense.ExpirationDate}\n";
            }
            return response;
        }
    }
}