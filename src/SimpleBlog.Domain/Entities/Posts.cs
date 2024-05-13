namespace SimpleBlog.Domain.Entities
{
    public class Posts
    {
        // Empty constructor for EF
        protected Posts() { }

        public Posts(Guid id, string title, string message, Guid userId, bool active)
        {
            Id = id;
            Title = title;
            Message = message;
            UserId = userId;
            Active = active;
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public bool Active { get; set; }

        public DateTime InclusionDate { get; set; }
        public DateTime ChangeDate { get; set; }

        public Users? Users { get; set; }

    }
}
