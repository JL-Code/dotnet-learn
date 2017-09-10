using MySql.Domain.AggregatesModel;
using System;
using System.Threading.Tasks;
using MySql.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace MySql.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly MySqlContext _context;


        public PostRepository(MySqlContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IUnitOfWork UnitOfWork => _context;

        public Post Add(Post post)
        {
          return  _context.Posts.Add(post).Entity;
        }

        public async Task<Post> GetAsync(string postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            return post;
        }

        public void Update(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
        }
    }
}
