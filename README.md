# Twilio Queue Dashboard Demo
Whether you're running a call center, just a small office, or have to deal with all of the incoming calls for that event tonight, putting people on hold (aka call queuing) is an important but often difficult process.

With the launch of Twilios new Queue functionality, its never been easier to build call queuing systems.

This sample demonstrates how to use the new Queue functionallity to place incoming calls into a call queue, as well as build a web dashboard that shows call queue stats.

![Queue Dashboard](https://raw.github.com/devinrader/Queue-Demo/master/queuedash.png)

Check out a live demo of this sample at http://twilio-queue.azurewebsites.net/

## Prerequisites
In order to run this sample you will need to ensure you have the following prerequisites installed:

* Visual Studio 2012 or later
* ASP.NET MVC 3 or later
* Windows Azure SDK for .NET

Additionally before you can run the sample you will need to replace several tokens in the source with your own values.

## Installation

This sample comes with a number of projects that you need to configure and deploy.  Lets walk through whats there and how to get it running.  To get started:

- If you don't already have one, create an Twilio account
- If you don't already have one, create a Windows Azure account
- Make sure you have the prequisites listed above installed

Next, grab the latest source code and open the solution in Visual Studio.  The solution contains four projects:

* Queue-Demo: An ASP.NET MVC website that handles Twilio call requests and contains the SignalR hub
* Queue-Demo-Azure: The Windows Azure publish project
* Queue-Demo-Worker: A Windows Azure Worker Role project that is responsible for polling the Twilio API and reteriving the average wait time for the Queue.
* Queue-Demo-Settings: A class library that contains Twilio and SignalR configuration settings.

Update the static properties in the Settings class:

```csharp
public static class Settings
{
    //Replace the values with your own Twilio AccountSid and AuthToken
    public static string accountSid = "[YOUR_ACCOUNT_SID]";
    public static string authToken = "[YOUR_AUTH_TOKEN]";

    //Replace the value below with the domain where your project will be deployed
    public static string hubUrl = "[YOUR_HUB_URL]";
}
```

Once you've updated the settings, deploy the Queue-Demo-Azure project to Windows Azure, and then deploy the Queue-Demo project to your web host.

Open your Twilio dashboard and configure your Twilio number to point to the CallController endpoint in the Queue-Demo website

## More Info

The full Queue documentation is available here:
http://www.twilio.com/docs/api/twiml/queue and http://www.twilio.com/docs/api/rest/queue

Built for explanation & demo purposes, September 2012.
