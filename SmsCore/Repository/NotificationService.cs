using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        public async Task SendSmsAsync(string? clientRequestId, string to, string message)
        {
            try
            {
                var providerService = await _smsProcessor.GetSmsProviderAsync(to.Trim());
                if(providerService != null)
                {
                    _logger.LogInformation($"No Sms Provider found");
                }
                //if (!status)
                //{

                //    await _notificationRequestAndResponse.SaveSmsLogAsync(clientRequestId, $"{to}:{message}", "No SMS provider configured yet for this phone code",
                //        "No SMS Provider", "", ErrorCodes.UNDEFINED_PROVIDER_ERROR.ToString(), MessageStatus.Failed);
                //    return;
                //}

                //var checkingDuplicate = await _queryNotification.GetSmsLogByClientIdAsync(clientRequestId);
                //if (checkingDuplicate.Any())
                //{
                //    return;
                //}


                var (smsStatus, generalSmsProviderResponse) = await providerService.SendSMSNotification(to, message, "");
                if (!smsStatus)
                {
                    await _notificationRequestAndResponse.SaveSmsLogAsync(clientRequestId, $"{to}:{message}", JsonConvert.SerializeObject(generalSmsProviderResponse),
                        generalSmsProviderResponse.ProviderName, "", ErrorCodes.FAILED_SMS_ERROR.ToString(), MessageStatus.Failed);
                    return;

                }
                await _notificationRequestAndResponse.SaveSmsLogAsync(clientRequestId, JsonConvert.SerializeObject(generalSmsProviderResponse.Request),
                    JsonConvert.SerializeObject(generalSmsProviderResponse.Response), generalSmsProviderResponse.ProviderName,
                    generalSmsProviderResponse.Code, generalSmsProviderResponse.MessageId,
                    generalSmsProviderResponse.MessageStatus);
            }
            catch (Exception x)
            {
                _logger.LogError($"ERROR Occured while trying in SendSmsAsync() {x.StackTrace}");
                throw;
            }


        }
        
       
    }
}
