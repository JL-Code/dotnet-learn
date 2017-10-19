using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace netcore.tests
{
    [TestClass]
    public class ZookeeperTest
    {
        [TestMethod]
        public void Zookeeper_Connect()
        {
            var zkManager = new ZookeeperManager("127.0.0.1:2181");
            var result = zkManager.GetNodeTree().Result;
            foreach (var item in result.Children)
            {
                Console.WriteLine(item);
            }
        }
    }
}
