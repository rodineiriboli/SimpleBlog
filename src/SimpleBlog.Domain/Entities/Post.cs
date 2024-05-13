namespace SimpleBlog.Domain.Entities
{
    public class Post : BaseDomain
    {
        public Guid PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public Guid PostUserId { get; set; }
    }
}
