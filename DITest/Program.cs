// See https://aka.ms/new-console-template for more information
using ConfigServices;
using LogService;
using MailServices;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");
ServiceCollection  services = new ServiceCollection();


using (var sp = services.BuildServiceProvider())
{
    //第一个根对象只能用ServiceLocator获取
    var mailservice = sp.GetRequiredService<IMailService>();
    services.addExpand();
    mailservice.send("邮件","张山","6xgtfwfg56156rf1fw42");
}

Console.ReadKey();

