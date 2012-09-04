using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SignalR.Hubs;

namespace Queue_Demo.Hubs
{
    [HubName("queue")]
    public class QueueHub : Hub
    {
        public void ReportAverageWait(string waitTime)
        {
            Clients.reportAverageWait(waitTime);
        }
    }
}