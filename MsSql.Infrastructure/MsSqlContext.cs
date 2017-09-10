using Microsoft.EntityFrameworkCore;
using MsSql.Domain.AggregatesModel;
using MsSql.Domain.SeedWork;
using MsSql.Infrastructure.EntityTypeConfiguration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MsSql.Infrastructure
{
    public class MsSqlContext : DbContext, IUnitOfWork
    {
        private MsSqlContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }


        public static MsSqlContext CreateForEFDesignTools(DbContextOptions options)
        {
            return new MsSqlContext(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
