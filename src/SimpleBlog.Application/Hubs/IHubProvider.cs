namespace SimpleBlog.Application.Hubs
{
    public interface IHubProvider
    {
        Task ReceiveMessage(string message);
    }
}
