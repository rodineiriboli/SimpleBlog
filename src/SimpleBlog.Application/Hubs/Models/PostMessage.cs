namespace SimpleBlog.Application.Hubs.Models
{
    public class PostMessage
    {
        public Guid IdPost { get; set; }
        public string Title { get; set; }
        public string BodyMessage { get; set; }
    }
}
