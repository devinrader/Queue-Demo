# Twilio Queue Dashboard Demo
Whether you're running a call center, just a small office, or have to deal with all of the incoming calls for that event tonight, putting people on hold (aka call queuing) is an important but often difficult process.

With the launch of Twilios new Queue functionality, its never been easier to build call queuing systems.

This sample demonstrates how to use the new Queue functionallity to place incoming calls into a call queue, as well as build a web dashboard that shows call queue stats.

![Queue Dashboard](https://raw.github.com/devinrader/Queue-Demo/master/queuedash.png)

Check out a live demo of this sample at http://twilio-queue.azurewebsites.net/

## Sample Prerequisites
In order to run this sample you will need to ensure you have the following prerequisites installed:

* Visual Studio 2012 or later
* ASP.NET MVC 3 or later
* Windows Azure SDK for .NET

Additionally before you can run the sample you will need to replace several tokens in the source with your own values.  Open the Settings class in the Queue-Demo-Settings project and replace the variable values.

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

## More Info

The full Queue documentation is available here:
http://www.twilio.com/docs/api/twiml/queue and http://www.twilio.com/docs/api/rest/queue

Built for explanation & demo purposes, September 2012.
