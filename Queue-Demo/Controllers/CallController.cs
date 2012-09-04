using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalR;
using Twilio;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace Queue_Demo.Controllers
{
    public class CallController : TwilioController
    {
        string accountSid = "[YOUR_ACCOUNT_SID]";
        string authToken = "[YOUR_AUTH_TOKEN]";

        public ActionResult QueueCall()
        {
            var response = new TwilioResponse();

            response.Enqueue("Demo Queue", new {
                action= Url.Action("LeaveQueue"),       //url to call when the call is dequeued
                waitUrl = Url.Action("WaitInQueue")    //url to call while the call waits
            });

            return TwiML(response);
        }


        public ActionResult WaitInQueue(string CurrentQueueSize, string QueuePosition)
        {
            var response = new TwilioResponse();

            var context = GlobalHost.ConnectionManager.GetHubContext<Hubs.QueueHub>();
            context.Clients.reportQueueSize(CurrentQueueSize);

            response.Say(string.Format("You are number {0} in the queue.  Please hold.", QueuePosition));
            response.Play("http://demo.brooklynhacker.com/music/ramones.mp3");

            return TwiML(response);
        }

        public ActionResult LeaveQueue(string QueueSid)
        {
            var client = new TwilioRestClient(accountSid, authToken);

            var queue  = client.GetQueue(QueueSid);

            if (queue.RestException == null)
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<Hubs.QueueHub>();
                context.Clients.reportQueueSize(queue.CurrentSize);
            }
            return new EmptyResult();
        }


        public ActionResult Dial()
        {
            var response = new TwilioResponse();
            response.DialQueue("Demo Queue", new { url = Url.Action("Connect") }, new { });

            return TwiML(response);
        }

        public ActionResult Connect()
        {
            var response = new TwilioResponse();
            response.Say("Connecting you to an agent");

            return TwiML(response);
        }
    }
}
