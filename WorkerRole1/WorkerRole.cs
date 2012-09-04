using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using SignalR.Client.Hubs;
using Twilio;

namespace Queue_Demo_Worker
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            var client = new TwilioRestClient(Queue_Demo.Settings.accountSid, Queue_Demo.Settings.authToken);

            var queue = client.ListQueues().Queues.Where(q => q.FriendlyName == "Demo Queue").FirstOrDefault();
                
            if (queue!=null)
            {
                var queueSid = queue.Sid;

                var conn = new HubConnection(Queue_Demo.Settings.hubUrl);
                var hub = conn.CreateProxy("Queue");

                conn.Start();

                while (true)
                {
                    Thread.Sleep(10000);

                    var waitTime = client.GetQueue(queueSid).AverageWaitTime;

                    Debug.WriteLine(waitTime);

                    hub.Invoke("ReportAverageWait", new object[] { waitTime });
                }
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}