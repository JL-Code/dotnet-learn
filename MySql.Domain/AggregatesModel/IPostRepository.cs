using MySql.Domain.SeedWork;
using System.Threading.Tasks;

namespace MySql.Domain.AggregatesModel
{
    public interface IPostRepository : IRepository<Post>
    {
        Post Add(Post post);

        void Update(Post post);

        Task<Post> GetAsync(string postId);
    }
}
