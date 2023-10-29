using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmsCore.Interface;
using SmsDomain.Domain;

namespace MessageBusConnection.ServiceExtension
{
    public class SendSmsConsumer : IConsumer<SmsNotificationRequestMessage>
    {
        private readonly ILogger<SendSmsConsumer> _logger;
        private readonly INotificationService _notificationService;

        public SendSmsConsumer(ILogger<SendSmsConsumer> logger, INotificationService notificationService)
        {
            _logger = logger;
            _notificationService = notificationService;
        }

        public async Task Consume(ConsumeContext<SmsNotificationRequestMessage> context)
        {
            try
            {

                _logger.LogInformation($"SendSmsConsumer receives a call from another service to send sms :{JsonConvert.SerializeObject(context.Message)}.");
                await _notificationService.SendSmsAsync(context.Message.ClientRequestId, context.Message.PhoneNumber, context.Message.MessageBody);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Occured in SendSmsConsumer...");
                throw;
            }
        }
    }
}