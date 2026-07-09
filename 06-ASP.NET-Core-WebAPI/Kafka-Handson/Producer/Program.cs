using Confluent.Kafka;

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092"
};

using var producer =
    new ProducerBuilder<Null, string>(config).Build();

Console.WriteLine("Enter messages:");

while (true)
{
    string message = Console.ReadLine();

    await producer.ProduceAsync(
        "chat-message",
        new Message<Null, string>
        {
            Value = message
        });

    Console.WriteLine("Sent : " + message);
}
