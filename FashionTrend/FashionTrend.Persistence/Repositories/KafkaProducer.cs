using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using System.Text.Json;

public class KafkaProducer : IKafkaProducer
{
    private readonly IProducer<string, string> _producer;
    private readonly ILogger<KafkaProducer> _logger;

    public KafkaProducer(ILogger<KafkaProducer> logger)
    {
        _logger = logger;
    }

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
            MessageId = Guid.NewGuid(),
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

    public async Task<Message> ProduceAsyncWithRetry(string topic, string sender, string receiver, string content)
    {
        var message = new Message
        {
            MessageId = Guid.NewGuid(),
            Sender = sender,
            Receiver = receiver,
            Content = content,
            Timestamp = DateTime.UtcNow,
            Status = "em processamento"

        };
        string serializedMessage = JsonSerializer.Serialize(message);


        int maxRetries = 3;
        int retryIntervalMs = 1000;

        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                var deliveryReport = await _producer.ProduceAsync(topic, new Message<string, string> { Value = serializedMessage });

                message.Status = "com sucesso";

            }
            catch (ProduceException<Null, string> ex)
            {
                Console.WriteLine($"Tentativa {attempt} falhou: {ex.Error.Reason}");

                if (attempt < maxRetries)
                {
                    _logger.LogTrace($"Tentando novamente em {retryIntervalMs / 1000} segundos...");
                    System.Threading.Thread.Sleep(retryIntervalMs);
                    message.Status = "retry";
                }
                else
                {
                    _logger.LogError(ex, "Ocorreu um erro no método ProduceAsyncWithRetry do KafkaProducer.");
                    throw;
                }
            }

        }
        return message;
    }
}
