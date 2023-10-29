namespace SmsCore.Interface
{
    public interface IMessagePublisher
    {
        Task Publish<T>(T message);
    }
}
