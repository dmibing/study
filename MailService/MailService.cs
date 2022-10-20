using ConfigServices;
using LogService;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailServices
{
    public class MailService : IMailService
    {
        public readonly IConfigService _configService;

        public readonly ILogProvider _logProvider;

        public MailService(IConfigService configService, ILogProvider logProvider)
        {
            _configService = configService;
            _logProvider = logProvider; 
        }

        public void send(string title, string to, string body)
        {

            _logProvider.LogInfo("开始发送邮件");
            string username = _configService.GetValue("张三");
            Console.WriteLine($"用户名{ username}");
            Console.WriteLine($"已经把邮件{title}{body}发送给了{to}");
            _logProvider.LogInfo("邮件发送完成");
        }
    }
}
