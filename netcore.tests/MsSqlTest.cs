using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsSql.Domain.AggregatesModel;
using MsSql.Domain.SeedWork;
using MsSql.Infrastructure;
using MsSql.Infrastructure.Repositories;
using System;

namespace netcore.tests
{
    [TestClass]
    public class MsSqlTest
    {
        IPostRepository _repo;
        MsSqlContext _context;

        [TestInitialize]
        public void Init()
        {
            var options = new DbContextOptionsBuilder<MsSqlContext>();
            options.UseSqlServer("server=.;uid=sa;pwd=123456;database=dev;");
            _context = MsSqlContext.CreateForEFDesignTools(options.Options);
            _repo = new PostRepository(_context);
        }


        [TestMethod]
        public void AddPost()
        {
            var post = new Post
            {
                PostId = Guid.NewGuid().ToString(),
                Title = "EF Core 2 Á¬½Ó sqlserver",
                Content = "ÄãºÃ sql server"
            };
            _repo.Add(post);
            _context.SaveChanges();
        }
    }
}
