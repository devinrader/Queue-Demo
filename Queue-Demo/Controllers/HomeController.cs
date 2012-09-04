using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalR.Client.Hubs;
using Twilio;

namespace Queue_Demo.Controllers
{
    public class HomeController : Controller
    {
        string hubUrl = "[YOUR_HUB_URL]";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Broadcast()
        {
            var conn = new HubConnection(hubUrl);

            var hub = conn.CreateProxy("queue");
            
            var waitTime = "1000";

            conn.Start().Wait();
            
            hub.Invoke("ReportAverageWait", new object[] { waitTime });

            return new EmptyResult();
        }
    }
}
