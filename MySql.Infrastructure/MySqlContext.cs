using Microsoft.EntityFrameworkCore;
using MySql.Domain.AggregatesModel;
using MySql.Domain.SeedWork;
using MySql.Infrastructure.EntityTypeConfiguration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MySql.Infrastructure
{
    public class MySqlContext : DbContext, IUnitOfWork
    {
        private MySqlContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }


        public static MySqlContext CreateForEFDesignTools(DbContextOptions options)
        {
            return new MySqlContext(options);
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
