using Microsoft.Extensions.Logging;
using SmsCore.Interface;

namespace SmsCore.Repository
{
    public class NotificationService : INotificationService
    {
        private readonly ISmsStrategyProcessor _smsProcessor;
        private readonly ILogger<NotificationService> _logger;
        private readonly IMessagePublisher _publisher;
        private readonly ISmsNotification _smsNotification;
        public NotificationService(ISmsStrategyProcessor smsProcessor, IMessagePublisher publisher, ISmsNotification smsNotification, ILogger<NotificationService> logger)
        {
            _smsProcessor = smsProcessor;
            _logger = logger;
            _publisher = publisher;
            _smsNotification = smsNotification;
        }
        public async Task SendSmsAsync(string clientRequestId, string to, string message)
        {
            try
            {
                //check inside sqlLite

                var providerService = await _smsProcessor.GetSmsProviderAsync(to.Trim());
                if (providerService == null)
                {
                    _logger.LogInformation($"No Sms Provider found");
                }
                var generalSmsProviderResponse = await providerService.SendSMSNotification(to, message, "MKOPA");
                //save inside log
                await _publisher.Publish("Event to be published");
            }
            catch (Exception x)
            {
                _logger.LogError($"ERROR Occured while trying in SendSmsAsync() {x.StackTrace}");
                throw;
            }
        }
    }
}
