using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Twilio;


namespace Queue_Demo.Hubs
{
    [HubName("queue")]
    public class QueueHub : Hub
    {
        public int ReportAverageWait()
        {
            var client = new TwilioRestClient(Queue_Demo.Settings.AccountSid, Queue_Demo.Settings.AuthToken);

            var queuesResult = client.ListQueues();

            if (queuesResult.RestException==null && queuesResult.Queues != null)
            {
                var demoqueue = queuesResult.Queues.Where(q => q.FriendlyName == "Demo Queue").FirstOrDefault();

                if (demoqueue != null)
                {
                    var queueSid = demoqueue.Sid;

                    var queue = client.GetQueue(queueSid);

                    var waitTime = queue.AverageWaitTime;

                    Debug.WriteLine(waitTime);

                    return waitTime.Value;
                }
            }

            throw new Exception();
        }
    }
}