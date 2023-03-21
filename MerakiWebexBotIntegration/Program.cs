using MerakiWebexBotIntegration.Clients.Implementation;
using MerakiWebexBotIntegration.Clients.Interfaces;
using MerakiWebexBotIntegration.Services.Implementation;
using MerakiWebexBotIntegration.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IBotService, BotService>();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<IMessageHttpService, MessageHttpService>();
builder.Services.AddTransient<ILicenceService, LicenceService>();
builder.Services.AddTransient<ILicencesHttpService, LicencesHttpService>();
builder.Services.AddTransient<IAttachmentActionService, AttachmentActionService>();
builder.Services.AddTransient<IAttachmentActionHttpService, AttachmentActionHttpService>();
builder.Services.AddTransient<IOrganizationsHttpService, OrganizationsHttpService>();
builder.Services.AddTransient<IOrganizationsService, OrganizationsService>();
builder.Services.AddTransient<IWebexClient, WebexClient>();
builder.Services.AddTransient<ICardService, CardService>();
builder.Services.AddTransient<IMessageDetailsService, MessageDetailsService>();
builder.Services.AddTransient<IMessageDetailsHttpService, MessageDetailsHttpService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();