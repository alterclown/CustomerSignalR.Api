using CustomerSignalR.Api.SignalR.Interface;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSignalR.Api.SignalR.Hub
{
    public class BroadcastHub : Hub<IHubClient>
    {
    }
}
