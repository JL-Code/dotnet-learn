using org.apache.zookeeper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace netcore.tests
{
    /// <summary>
    /// 用于监控 Client 与 Zookeeper服务器连接成功
    /// </summary>
    public class ConnectionWatcher : Watcher
    {
        private readonly Action _connectioned;
        private readonly Action _disconnect;

        public ConnectionWatcher(Action connectioned, Action disconnect)
        {
            _connectioned = connectioned;
            _disconnect = disconnect;
        }

        /// <summary>
        /// 处理
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public override async Task process(WatchedEvent @event)
        {
            if (@event.getState() == Event.KeeperState.SyncConnected)
            {
                _connectioned();
            }
            else
            {
                _disconnect();
            }
#if NET
                await Task.FromResult(1);
#else
            await Task.CompletedTask;
#endif
        }

    }
}
