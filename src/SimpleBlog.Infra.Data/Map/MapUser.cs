using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Infra.Data.Map
{
    public class MapUser : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable(nameof(Users).ToLower());

            builder.Property(p => p.Id).HasColumnName(nameof(Users.Id).ToLower()).IsRequired();

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(100).HasColumnName(nameof(Users.Name).ToLower()).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(100).HasColumnName(nameof(Users.Email).ToLower()).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(100).HasColumnName(nameof(Users.Password).ToLower()).IsRequired();
            builder.Property(p => p.SaltKey).HasMaxLength(100).HasColumnName(nameof(Users.SaltKey).ToLower()).IsRequired();
            builder.Property(p => p.Active).HasColumnName(nameof(Users.Active).ToLower()).IsRequired();
            builder.Property(p => p.InclusionDate).HasColumnName(nameof(Users.InclusionDate).ToLower()).IsRequired();
        }
    }
}
