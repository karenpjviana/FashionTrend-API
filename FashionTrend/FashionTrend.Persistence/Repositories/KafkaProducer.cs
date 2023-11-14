using Confluent.Kafka;
using System.Text.Json;

public class KafkaProducer : IKafkaProducer
{
    private readonly IProducer<string, string> _producer;

    public KafkaProducer()
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092",
        };
        _producer = new ProducerBuilder<string, string>(config).Build();
    }

    public async Task<Message> ProduceAsync(string topic, string sender, string receiver, string content)
    {
        var message = new Message
        {
            id = Guid.NewGuid(),
            Sender = sender,
            Receiver = receiver,
            Content = content,
            Timestamp = DateTime.UtcNow,
            Status = "em processamento"
        };

        string serializedMessage = JsonSerializer.Serialize(message);

        var deliveryReport = await _producer.ProduceAsync(topic, new Message<string, string>
        {
            Value = serializedMessage
        }); 

        if(deliveryReport.Status == PersistenceStatus.NotPersisted)
        {
            message.Status = " com erro";
            return message;
        }
        else
        {
            message.Status = " com sucesso";
            return message;
        }
    }
}
