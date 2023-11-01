using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MessageBusConnection.ServiceExtension
{
    public class MessagingBusService : IHostedService
    {
        private readonly IBusControl _busControl;
        private readonly ILogger<MessagingBusService> _logger;

        public MessagingBusService(IBusControl busControl, ILogger<MessagingBusService> logger)
        {
            _busControl = busControl;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started Messaging bus for SMS Service");

            return _busControl.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopped Messaging bus for SMS Service");

            return _busControl.StopAsync(cancellationToken);
        }
    }
}