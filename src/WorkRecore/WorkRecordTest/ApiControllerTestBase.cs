using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.IO;
using System.Net.Http;
using WorkRecord.API;

namespace WorkRecordTest
{
    /// <summary>
    /// 基类，返回HttpClient对象
    /// </summary>
    public class ApiControllerTestBase
    {
        protected HttpClient GetClient()
        {
            var builder = new WebHostBuilder()
                                // 指定使用当前目录
                                 .UseContentRoot(Directory.GetCurrentDirectory())
                                // 使用Startup类作为启动类
                                .UseStartup<Startup>();
                                // 设置使用测试环境
                                //.UseEnvironment("Testing");
            var server = new TestServer(builder);
            // 创建HttpClient
            HttpClient client = server.CreateClient();

            return client;
        }
    }
}
