namespace SimpleBlog.Domain.Entities
{
    public class User : BaseDomain
    {
        public User(Guid userIdInclusion, DateTime includeDate) : base(userIdInclusion, includeDate)
        {
        }

        public Guid UserId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
    }
}
