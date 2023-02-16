
using RabbitMQ.Client;
using System.Text;

var connFactory = new ConnectionFactory();   //   
connFactory.HostName = "127.0.0.1";   //链接地址
connFactory.DispatchConsumersAsync = true;   //是否启用异步发送消息
var connection = connFactory.CreateConnection();    //创建物理链接  基于tcp
while (true)
{
    using var chanel = connection.CreateModel();  //创建虚拟信道
    var prop = chanel.CreateBasicProperties();  //消息配置
    prop.DeliveryMode = 2;  //消息是否持久化
    chanel.ExchangeDeclare("myexchange","direct");  //声明交换机  名称  类型
    chanel.QueueDeclare("myqueue", false, false, false, null);  //对列声明
    chanel.QueueBind("myqueue", "myexchange", "mykey");   //对列绑定
    string msg = "Hello Syy";
    Byte[]  bytes = Encoding.UTF8.GetBytes(msg);   //把消息转换为字节
    chanel.BasicPublish("myexchange", "myqueue", true,prop,bytes);
    Console.WriteLine($"已发送{msg}");
}

