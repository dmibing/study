
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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
    chanel.ExchangeDeclare("myexchange", "direct");  //声明交换机  名称  类型
    chanel.QueueDeclare("myqueue", false, false, false, null);  //对列声明
    chanel.QueueBind("myqueue", "myexchange", "mykey");   //对列绑定

    AsyncEventingBasicConsumer consumer = new AsyncEventingBasicConsumer(chanel);
    consumer.Received += Consumer_Received;
    chanel.BasicConsume("myqueue", false,consumer);
    async Task Consumer_Received(object  sender,BasicDeliverEventArgs e)
    {
        try
        {
            var msg = Encoding.UTF8.GetString(e.Body.ToArray());
            Console.WriteLine("消息处理成功"+ msg);
            chanel.BasicAck(e.DeliveryTag, false); //确认消息处理成功了
            await Task.Delay(1000);
        }
        catch (Exception)
        {
            //处理失败拒绝消息
            chanel.BasicAck(e.DeliveryTag, true); 
            Console.WriteLine("消息处理出错");
        }
    }

}