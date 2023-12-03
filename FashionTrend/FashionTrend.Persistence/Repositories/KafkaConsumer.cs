using Confluent.Kafka;
using Microsoft.Extensions.Logging;

public class KafkaConsumer : IKafkaConsumer
{
    private bool isConsuming = false;

    public event EventHandler<MessageReceivedEventArgs> OnMessageReceived;

    private IConsumer<Ignore, string> consumer;

    private readonly ILogger<KafkaConsumer> _logger;

    public async Task StartConsumingAsync(CancellationToken cancellationToken)
    {
        isConsuming = true;
        while (isConsuming)
        {
            try
            {
                var consumeResult = await Task.Run(() => consumer.Consume(cancellationToken), cancellationToken);
                if (consumeResult != null && consumeResult.Message != null)
                {
                    string message = consumeResult.Message.Value;
                    OnMessageReceived?.Invoke(this, new MessageReceivedEventArgs { Message = message });
                }
                StopConsuming();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro no método StartConsumingAsync no KafkaConsumer.");
                throw;
            }
        }
    }

    public void StopConsuming()
    {
        isConsuming = false;
        consumer.Close();
    }

    public void Subscribe(string topic, string group)
    {
        try
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = group,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false
            };

            consumer = new ConsumerBuilder<Ignore, string>(config).Build();

            consumer.Subscribe(topic);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Subscribe no KafkaConsumer.");
            throw;
        }
    }
}