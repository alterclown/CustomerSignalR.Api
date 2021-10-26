using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSignalR.Api.SignalR.Interface
{
    public interface IHubClient
    {
        Task BroadcastMessage();
    }
}
