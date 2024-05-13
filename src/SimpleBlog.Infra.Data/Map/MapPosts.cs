using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Infra.Data.Map
{
    public class MapPosts : IEntityTypeConfiguration<Posts>
    {
        public void Configure(EntityTypeBuilder<Posts> builder)
        {
            builder.ToTable(nameof(Posts).ToLower());

            builder.Property(p => p.Id).HasColumnName(nameof(Posts.Id).ToLower()).IsRequired();
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title).HasMaxLength(50).HasColumnName(nameof(Posts.Title).ToLower()).IsRequired();
            builder.Property(p => p.Message).HasMaxLength(300).HasColumnName(nameof(Posts.Message).ToLower()).IsRequired();
            builder.Property(p => p.UserId).HasColumnName(nameof(Posts.UserId).ToLower()).IsRequired();
            builder.Property(p => p.Active).HasColumnName(nameof(Posts.Active).ToLower()).IsRequired();
            builder.Property(p => p.InclusionDate).HasConversion(p => p.ToUniversalTime(), p => DateTime.SpecifyKind(p, DateTimeKind.Utc))
                .HasColumnName(nameof(Posts.InclusionDate).ToLower()).IsRequired();
            builder.Property(p => p.ChangeDate).HasConversion(p => p.ToUniversalTime(), p => DateTime.SpecifyKind(p, DateTimeKind.Utc))
                .HasColumnName(nameof(Posts.ChangeDate).ToLower());

            builder.HasOne(e => e.Users)
                   .WithMany(e => e.Posts)
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}