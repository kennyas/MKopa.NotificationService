using Microsoft.Extensions.Logging;
using SmsCore.Dto;
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
        public async Task<SmsProviderResponse> SendSmsAsync(string clientRequestId, string to, string message)
        {
            SmsProviderResponse generalSmsProviderResponse = new();
            try
            {
                //check inside sqlLite for already sent sms by clientRequestId

                //Implement the logic for preventing duplicates based on the db filter response

                //proceed to trigger a call to the sms provider after confirming no duplicate

                var providerService = await _smsProcessor.GetSmsProviderAsync(to.Trim());
                if (providerService == null)
                {
                    _logger.LogInformation($"No Sms Provider found");
                    return generalSmsProviderResponse;
                }
                generalSmsProviderResponse = await providerService.SendSMSNotification(to, message, "MKOPA");
                //save inside log

                //Implement logic to save sms logs to a database server, it can be an sql lite
                

                // publish event for  successfully sent sms
                await _publisher.Publish("Event to be published");

                return generalSmsProviderResponse;
            }
            catch (Exception x)
            {
                _logger.LogError($"ERROR Occured while trying to SendSmsAsync() {x.StackTrace}");
                throw;
            }
        }
    }
}
