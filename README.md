# Webex Bot Meraki Integration

**Bot** for easy access to meraki co-term licences information

# Technical challenge

Our customer had a process to renew the different licences of their own customers, a step of this process consisted in periodically asking our meraki expert when those license wuold expire, this was very inefficient and very time consuming, thus we decided since they already had webex nd were already famliar with bots to create this project. 

# Proposed solution

An Api that will be called by a **Webex** bot through a **Webex** webhook, this api will get the data of our customer organizations and their licences from meraki, elaborate it and present it to the user. 

# How it works
The user can write any text to the bot, if it finds any organizations containing that name it will send you a list of those organizations and their licence expiration dates. if the bot does not find any organization whose name contains the sent text, it will instead send the user a card that will contain two buttons, one that shows the organization list with their respective Ids, and one that shows the customer list with their respective license expiration dates.

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


# How to publish

I will illustratte the publishing on iis(Internet information service) process using visual studio
right click on the MerakiWebexBotIntegrationProject inside visual studio
click on publish
select the folder option 
create your publish profile, the following is the one that was used to publish this project:

Target Location: select a local folder where you want to see the published files

Configuration: Release
Target Framework: .Net 6.0
Deployment Mode: Framework Dependant
Target Runtime: Portable

after completing your profile click save and then press publish, if every step was executed successfully you should see in your selcted folder trhe published files, create a zip containing said files and move it to the server where the code will be published (Note: the server need to have the required package to run a .Net6.0 application https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

exctract the code and put it inside the folder that will be referenced by iis.

open iis 

install your ssl certificate (https://support.globalsign.com/ssl/ssl-certificates-installation/how-install-ssl-certificate-iis-10)

create a new application pool for the project, right click on Application Pools and select Add Application Pool
the following was the configuration of the application pool created for our publish:
Nane: a name of your choice
.Net CLR version: No managed code
Managed pipeline mode : Integrated
and tick the box start application pool immediately

create a new site, right click on Sites and select Add Website

use the following configuration:

Site Name: a name of your choice
Application pool: the application pool we just created
Physical path: the path of the folder where we extracted our published code

in the binding section
Type: select Https
Ip Address: All unassigned
Port: the port where you want your api to respond
Host Name: the url at which the api will respond
SSL certificate: the ssl certificate that verifies your api (Note webex will call this api therefore in need to be reachable trough internet and needs to be in https, if the api is published in http or is not reachable trough internet the project will not work)


Now that our Api is published we need to establish the connection between it and the bot, to do this we will create two webex webhooks that will call both of our endpoints

To create a webex Webhook you need to male a Post call to following endpoint https://webexapis.com/v1/webhooks you can use postman to do this or you can use the webex dashboard which is what i'll base this example on:

go to the following url https://developer.webex.com/docs/api/v1/webhooks/create-a-webhook

login with your account

unflag the check Use Personal Access Token and instead use the bot access token

we will first create the webhook that fires when a message is sent to our bot 
to do this we will make the call with the following parameters

- name : a name of your choice
- targetUrl: the url of your api with a /bot/card added at the end
- resource: messages
- event: created

next we will create a webhook that fires when the user selects one of the options of our card
to do this we use the following parameters:
- name : a name of your choice
- targetUrl:  the url of your api with a /bot added at the end
- resource: attachmentActions
- event: created

Note: if you want a different endpoint than /bot and /bot/card you can change it by changing the route attributes in the BotController File

if you followed every step correctly you should be able to see your bot in your webex chat and by sending it a message you should receive the expected reply. 
