using MerakiWebexBotIntegration.Dto;
using MerakiWebexBotIntegration.Enums;
using MerakiWebexBotIntegration.Services.Interfaces;

namespace MerakiWebexBotIntegration.Services.Implementation
{
    public class CardService : ICardService
    {
        private readonly IMessageService _messageService;
        public CardService(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public async Task<HttpResponseMessage> PostCard(string PersonId)
        {
            var requestDto = new MessageRequestDto
            {
                Text = "text",
                ToPersonId = PersonId,
                Attachments = new List<AttachmentDto>
                {
                    new AttachmentDto
                    {
                        ContentType = "application/vnd.microsoft.card.adaptive",
                        Content = new ContentDto
                        {
                            Type = "AdaptiveCard",
                            Schema = "http://adaptivecards.io/schemas/adaptive-card.json",
                            Version = "1.2",
                            Body = new List<BodyDto>
                            {
                                new BodyDto
                                {
                                    Type = "Container",
                                    Style = "accent",
                                    Bleed = true,
                                    Items = new List<BodyDto>
                                    {
                                        new BodyDto
                                        {
                                            Type = "TextBlock",
                                            Text = "Available actions:",
                                            Wrap = true,
                                            Size = "Medium",
                                            Weight = "Bolder",
                                            HorizontalAlignment = "Center",
                                            Color = "Accent"
                                        }
                                    }
                                },
                                new BodyDto
                                {
                                    Type = "ColumnSet",
                                    Columns = new List<BodyDto>
                                    {
                                        new BodyDto
                                        {
                                            Type = "Column",
                                            Width = "stretch",
                                            Items = new List<BodyDto>
                                            {
                                                new BodyDto
                                                {
                                                    Type = "ActionSet",
                                                    HorizontalAlignment = "Right",
                                                    Actions = new List<ActionDto>
                                                    {
                                                        new ActionDto
                                                        {
                                                            Type = "Action.Submit",
                                                            Title = "Show customer list",
                                                            Data = new {command = (int)Command.ListOrganizations}
                                                        }
                                                    }
                                                }
                                            }
                                        },
                                        new BodyDto
                                        {
                                            Type = "Column",
                                            Width = "stretch",
                                            Items = new List<BodyDto>
                                            {
                                                new BodyDto
                                                {
                                                    Type = "ActionSet",
                                                    HorizontalAlignment = "Left",
                                                    Actions = new List<ActionDto>
                                                    {
                                                        new ActionDto
                                                        {
                                                            Type = "Action.Submit",
                                                            Title = "Show license list",
                                                            Data = new {command = (int)Command.ListLicensens}
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                },
                                new BodyDto
                                {
                                    Type = "TextBlock",
                                    Text = " - Are you looking for a specific license? Try typing the organitazion name.",
                                    Wrap = true,
                                    Size = "Small",
                                    Color = "Good",
                                    Separator = true
                                }
                            }
                        }
                    }
                }
            };
            return await _messageService.SendMessageAsync(requestDto);
        }
    }
}