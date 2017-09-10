using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsSql.Domain.AggregatesModel;
using MsSql.Infrastructure;
using MsSql.Infrastructure.Repositories;
using System;

namespace netcore.tests
{
    [TestClass]
    public class MySqlTest
    {
        IPostRepository _repo;
        MsSqlContext _context;

        [TestInitialize]
        public void Init()
        {
            var options = new DbContextOptionsBuilder<MsSqlContext>();
            options.UseMySql("server=192.168.31.54;userid=root;pwd=Jiang.2527786719;port=3306;database=dev;");
            _context = MsSqlContext.CreateForEFDesignTools(options.Options);
            _repo = new PostRepository(_context);
        }


        [TestMethod]
        public void AddPost()
        {
            var post = new Post
            {
                PostId = Guid.NewGuid().ToString(),
                Title = "EF Core 2 连接 mysql",
                Content = "你好 mysql"
            };
            _repo.Add(post);
            _context.SaveChanges();
        }
    }
}
