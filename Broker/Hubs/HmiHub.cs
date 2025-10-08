using Microsoft.AspNetCore.SignalR;

namespace Broker.Hubs
{
    public class HmiHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
    }
}
