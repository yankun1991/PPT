using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading;

namespace MvcApplication3
{
    public class MyConnection1 : PersistentConnection
    {
        /// <summary>
        /// 当前连接数
        /// </summary>
        private static int _connections = 0;
        /// <summary>
        /// 连接建立时执行
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        protected override async Task OnConnected(IRequest request, string connectionId)
        {
            //原子操作,防止多条现成同时+1而只做一次变化
            Interlocked.Increment(ref _connections);
            //await Connection.Send(connectionId, "Hi, " + connectionId + "!");
            await Connection.Broadcast("欢迎大家参加国内游研发周例会!");
        }
        /// <summary>
        /// 连接关闭时执行
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            //原子操作,防止多条现成同时-1而只做一次变化
            Interlocked.Decrement(ref _connections);
            return Connection.Broadcast("又调皮了");
        }
        /// <summary>
        /// 连接开始时执行
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            var message = connectionId + ">> " + data;
            return Connection.Broadcast(message);
        }
    }
}