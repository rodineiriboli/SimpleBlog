namespace SimpleBlog.Domain.Entities
{
    public class Users
    {
        // Empty constructor for EF
        protected Users() { }

        public Users(Guid id, string name, string email, string password, string saltkey)
        {
            Id = id;
            Name = name;
            Email = email;
            SaltKey = saltkey;
            Password = password;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SaltKey { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Active { get; set; }
        public DateTime InclusionDate { get; set; }
    }
}