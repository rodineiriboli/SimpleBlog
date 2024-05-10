namespace SimpleBlog.Domain.Entities
{
    public class Post : BaseDomain
    {
        public Post(Guid userIdInclusion, DateTime inclusionDate) : base(userIdInclusion, inclusionDate)
        {
        }

        public Guid PostId { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Message { get; private set; } = string.Empty;

        public Guid PostUserId { get; private set; }

    }
}
