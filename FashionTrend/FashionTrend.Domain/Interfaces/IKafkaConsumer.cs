public interface IKafkaConsumer
{
    event EventHandler<MessageReceivedEventArgs> OnMessageReceived;
    void Subscribe(string topic, string group);
    Task StartConsumingAsync(CancellationToken cancellationToken);
    void StopConsuming();
}
