using ConfigServices;
using LogService;
using MailServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection  //在微软依赖注入的命名空间下
{
    internal static class Expand
    {

        //添加  ServiceCollection 的拓展方法（同.netcore 中添加各种中间件）  在program中直接调用此方法
        public static void addExpand(this ServiceCollection service)
        {
            service.AddScoped<IConfigService, ConfigService>();
            service.AddScoped<ILogProvider, ConsoleLogProvider>();
            service.AddScoped<IMailService, MailService>();
        }
    }
}
