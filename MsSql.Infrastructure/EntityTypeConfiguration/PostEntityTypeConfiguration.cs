using Microsoft.EntityFrameworkCore;
using MsSql.Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MsSql.Infrastructure.EntityTypeConfiguration
{
    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");
            builder.HasKey(t => t.PostId);
        }
    }
}
