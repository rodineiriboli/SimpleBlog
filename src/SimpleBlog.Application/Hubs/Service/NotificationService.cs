using Microsoft.AspNetCore.SignalR;
using SimpleBlog.Application.Hubs.Models;

namespace SimpleBlog.Application.Hubs.Service
{
    public sealed class NotificationService(IHubContext<NotificationHub> hubContext) : INotificationService
    {
        public Task SendNotificationAsync(Notification notification) =>
            notification is not null
                ? hubContext.Clients.All.SendAsync("NotificationReceived", notification)
                : Task.CompletedTask;
    }
}
