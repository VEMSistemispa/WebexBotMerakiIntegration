# Webex Bot Meraki Integration

**Bot** for easy access to meraki co-term licences information

# Technical challenge

Our customer had a process to renew the different licences of their own customers, a step of this process consisted in periodically asking our meraki expert when those license wuold expire, this was very inefficient and very time consuming, thus we decided since they already had webex nd were already famliar with bots to create this project. 

# Proposed solution

An Api that will be called by a **Webex** bot through a **Webex** webhook, this api will get the data of our customer organizations and their licences from meraki, elaborate it and present it to the user. 

# How it works
The user can write any text to the bot, if it finds any organizations containing that name it will send you a list of those organizations and their licence expiration dates. if the bot does not find any organization matching the text it will instead send the user a card that will contain two buttons, one that shows the organization list and one that shows the customer list with their respective license expiration date.

# Technologies and tools

Main technologies:

- [.Net 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [Webex](https://www.webex.com/it)
- [Meraki](https://meraki.cisco.com)

# Requirements

- a **Webex** account with permissions to bots that can read and wite messages.
- a **Meraki** account that with permissions to read the organization's information
- an ssl certificate this will be used when publishing our Apis.


# Installation

Clone the repo
git clone https://github.com/VEMSistemispa/WebexBotMerakiIntegration.git

using fork click on files and select clone

> If you don't have fork installed you may download it here (https://git-fork.com/)

a modal will appear asking for the Repository Url(here we'll paste the cloned url) , the parent folder(the folder where you want the project to be) and the project name

after filling in the required fields press clone.

you can now open code in you IDE of choice, such as visual studio (for this guide i will be using visual studio 2022 as a reference).

> if you don't have visual studio you may download it here (https://visualstudio.microsoft.com/it/downloads/)


To start the project you will need to complete the **configuration** step and then press F5

### Configuration

Inside `appsettings.json` there are some empty fields that we need to fill in. 

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "Meraki": {
    "ApiKey": "" // insert the api key of the meraki account here
  },
  "Webex": {
    "BotAccessToken": "" // insert the access token of the webex bot here
  },
  "AllowedHosts": "*"
}

```
the card that is sent to the user is built dynamically, so it is possible to customize what it shows, the card is created in the CarsService file, inside the method PostCard

# Setup

1) Create a **Webex** bot, save the access token, this will be used later.(https://developer.webex.com/my-apps/new/bot)
2) Get the apikey of the meraki account and save it. (https://account.meraki.com/login/dashboard_login?go=%2F)
3) Put the api key inside the appsettings.json file under the section ApiKey inside the section Meraki.
4) Put the bot access token inside the BotAccessToken section under the section Webex.
5) Publish the api on iis, use the ssl certificate
6) create a **Webex** webhook using the bot access token and the following parameters:
- name : a name of your choice
- targetUrl: the url of your api with a /card added at the end
- resource: messages
- event: created
7) create another **Webex** webhook using the bot access token and the following parameters:
- name : a name of your choice
- targetUrl: the url of your api
- resource: attachmentActions
- event: created
