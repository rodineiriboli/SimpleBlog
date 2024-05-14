
using Microsoft.AspNetCore.SignalR;
using SimpleBlog.Application.Hubs.Models;

namespace SimpleBlog.Application.Hubs
{
    public sealed class NotificationHub : Hub
    {
        public async Task SendMessage(Notification notification)
        {
            await Clients.All.SendAsync("ReceiveMessage", notification);
        }
    }
}
