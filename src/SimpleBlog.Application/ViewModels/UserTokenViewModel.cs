namespace SimpleBlog.Application.ViewModels
{
    public class UserTokenViewModel
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public bool Active { get; set; }
        public DateTime InclusionDate { get; set; }
    }
}
