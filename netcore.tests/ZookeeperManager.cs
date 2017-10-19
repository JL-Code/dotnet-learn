using org.apache.zookeeper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace netcore.tests
{
    public class ZookeeperManager
    {
        private readonly int SESSION_TIMEOUT;
        private readonly string HOST;
        protected ZooKeeper zk;
        //手动复位事件
        private readonly ManualResetEvent _connectionWait = new ManualResetEvent(false);


        public ZookeeperManager(string host, int timeout = 5000)
        {
            HOST = host;
            SESSION_TIMEOUT = timeout;
            ConnectZookeeper().Wait();
        }


        public async Task<ChildrenResult> GetNodeTree()
        {
            return await GetNodes("/");
        }

        /// <summary>
        /// 获取Zookeeper节点集合
        /// </summary>
        /// <param name="path">节点父级路径</param>
        /// <returns></returns>
        public async Task<ChildrenResult> GetNodes(string path)
        {
            return await zk.getChildrenAsync(path);
        }

        /// <summary>
        /// 连接Zookeeper服务器
        /// </summary>
        /// <param name="host">Zookeeper服务器地址</param>
        /// <param name="timeout">连接超时 以毫秒作为单位</param>
        private async Task ConnectZookeeper()
        {
            if (zk != null)
                await zk.closeAsync();
            zk = new ZooKeeper(HOST, SESSION_TIMEOUT, new ConnectionWatcher(() =>
            {
                _connectionWait.Set();
            }, async () =>
            {
                _connectionWait.Reset();
                await ConnectZookeeper();
            }));

        }

    }
}
