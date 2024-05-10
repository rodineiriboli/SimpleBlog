namespace SimpleBlog.Domain.Entities
{
    public class BaseDomain
    {
        public BaseDomain(Guid userIdInclusion, DateTime inclusionDate)
        {
            Active = true;
            UserIdInclusion = userIdInclusion;
            InclusionDate = inclusionDate;
        }

        public bool Active { get; private set; }
        public Guid UserIdInclusion { get; private set; }
        public Guid UserChanged { get; private set; }
        public DateTime InclusionDate { get; private set; }
        public DateTime ChangeDate { get; private set; }
    }
}
