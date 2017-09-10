using MsSql.Domain.SeedWork;

namespace MsSql.Domain.AggregatesModel
{
    public class Post : Entity, IAggregateRoot
    {
        public string PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
