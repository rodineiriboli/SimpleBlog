namespace SimpleBlog.Application.ViewModels
{
    public class PostViewModelResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public bool Active { get; set; }

        public DateTime InclusionDate { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
