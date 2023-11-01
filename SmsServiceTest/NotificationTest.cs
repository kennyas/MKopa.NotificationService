using Microsoft.Extensions.Logging;
using Moq;
using SmsCore.Dto;
using SmsCore.Interface;
using SmsCore.Repository;

namespace SmsServiceTest
{
    [TestFixture]
    public class SmsNotificationTests
    {
        private readonly Mock<ILogger<NotificationService>> _mockedLogger;
        private readonly Mock<ISmsStrategyProcessor> _smsProvider;
        private readonly Mock<IMessagePublisher> _messagePublisher;
        private readonly Mock<ISmsNotification> _smsNotification;
        private readonly NotificationService _notificationService;
        
        public SmsNotificationTests()
        {
            _notificationService = new NotificationService(_smsProvider.Object, _messagePublisher.Object, _smsNotification.Object, _mockedLogger.Object);
        }
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public async Task Sms_Sent_Async()
        {
            //expected
            SmsProviderResponse smsProviderResponse = new SmsProviderResponse();
            smsProviderResponse.ResponseMessage = "success";
            smsProviderResponse.ResponseCode = "00";
            var result = await _notificationService.SendSmsAsync("1", "+2347063080436", "notification of loan falling due");
            Assert.That(smsProviderResponse, Is.EqualTo(result));
        }

        [Test]
        public async Task Sms_Not_SentAsync()
        {
            //expected
            SmsProviderResponse smsProviderResponse = new SmsProviderResponse();
            smsProviderResponse.ResponseMessage = "failed";
            smsProviderResponse.ResponseCode = "99";
            var result = await _notificationService.SendSmsAsync("1", "+2347063080436", "notification of loan falling due");
            Assert.That(result, Is.Not.EqualTo(smsProviderResponse));
        }

        [Test]
        public async Task Sms_Bad_Request_Async()
        {
            //expected
            SmsProviderResponse smsProviderResponse = new SmsProviderResponse();
            var result = await _notificationService.SendSmsAsync("1", "+080436", "notification of loan falling due");
            Assert.That(result, Is.EqualTo(smsProviderResponse));
        }
        
    }
}