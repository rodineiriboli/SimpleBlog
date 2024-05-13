namespace SimpleBlog.Application.ViewModels
{
    public class UserViewModelResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Active { get; set; } = false;
        public DateTime InclusionDate { get; set; }
    }
}
