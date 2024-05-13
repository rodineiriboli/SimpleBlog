
using Microsoft.AspNetCore.SignalR;
using SimpleBlog.Application.Hubs.Models;

namespace SimpleBlog.Application.Hubs
{
    public sealed class HubProvider : Hub<IHubProvider>
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.ReceiveMessage("ReceiveMessage");
        }

        public async Task SendMessage(PostMessage message)
        {
            await Clients.All.ReceiveMessage($"{message}");
        }
    }
}
