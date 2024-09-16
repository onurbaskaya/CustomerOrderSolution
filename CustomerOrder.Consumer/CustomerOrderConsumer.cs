using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

public class CustomerOrderConsumer
{
    private readonly IModel _channel;

    public CustomerOrderConsumer(IConnectionFactory connectionFactory)
    {
        var connection = connectionFactory.CreateConnection();
        _channel = connection.CreateModel();
        _channel.QueueDeclare(queue: "order_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
    }

    public void StartConsuming()
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Received: {message}");
        };
        _channel.BasicConsume(queue: "order_queue", autoAck: true, consumer: consumer);
    }
}
