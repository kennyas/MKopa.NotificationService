using MassTransit;
using SmsCore.Interface;

namespace SmsCore.Repository
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IBus _bus;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public MessagePublisher(IBus bus)
        {
            _bus = bus;
        }

        public async Task Publish<T>(T message)
        {
            await Task.Run(() =>
            {
                _bus.Publish(message, _cancellationTokenSource.Token);
            });
        }
    }
}
