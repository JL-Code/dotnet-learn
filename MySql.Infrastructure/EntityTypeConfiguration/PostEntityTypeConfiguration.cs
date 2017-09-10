using Microsoft.EntityFrameworkCore;
using MySql.Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MySql.Infrastructure.EntityTypeConfiguration
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
