using SimpleBlog.Application.Hubs.Models;

namespace SimpleBlog.Application.Hubs.Service
{
    public interface INotificationService
    {
        Task SendNotificationAsync(Notification notification);
    }
}
