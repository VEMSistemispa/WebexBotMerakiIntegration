# Webex Bot Meraki Integration

**Bot** for easy access to meraki co-term licences information

# Technical challenge

Our customer had a process to renew the different licences of their own customers, a step of this process consisted in periodically asking our meraki expert when those license wuold expire, this was very inefficient and very time consuming, thus we decided since they already had webex nd were already famliar with bots to create this project. 

# Proposed solution

A **Webex** bot that through a **Webex** webhook calls an Api that gets the data of our customer organizations and their licences from meraki, elaborates it and presents it to the user. 

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

#Setup

1) Create a **Webex** bot, save the access token, this will be used later.
2) Get teh apikey of the meraki account and save it.
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
