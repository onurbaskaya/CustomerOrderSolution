// CustomerOrder.Consumer/Program.cs

using RabbitMQ.Client;
using System;

namespace CustomerOrder.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CustomerOrder Consumer Başlatılıyor...");

            IConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = "localhost" 
            };

            var consumer = new CustomerOrderConsumer(connectionFactory);
            consumer.StartConsuming();

            Console.WriteLine("Kapatmak için bir tuşa basın...");
            Console.ReadLine();
        }
    }
}
