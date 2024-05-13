namespace SimpleBlog.Domain.Entities
{
    public class BaseDomain
    {
        public bool Active { get; set; }
        public Guid UserIdInclusion { get; set; }
        public Guid UserChanged { get; set; }
        public DateTime InclusionDate { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
