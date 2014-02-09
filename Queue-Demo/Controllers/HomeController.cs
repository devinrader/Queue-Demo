using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;

namespace Queue_Demo.Controllers
{
    public class HomeController : Controller
    {
        static string ApplicationSid = "[YOUR_TWIML_APP_SID]";
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agent(string id)
        {
            var capability = new TwilioCapability(Settings.AccountSid, Settings.AuthToken);

            capability.AllowClientIncoming(id);
            capability.AllowClientOutgoing(ApplicationSid);

            ViewBag.token = capability.GenerateToken();

            return View();
        }

        public ActionResult Broadcast()
        {
            //var conn = new HubConnection(Queue_Demo.Settings.HubUrl);

            //var hub = conn.CreateProxy("queue");
            
            //var waitTime = "1000";

            //conn.Start().Wait();
            
            //hub.Invoke("ReportAverageWait", new object[] { waitTime });

            return new EmptyResult();
        }
    }
}
