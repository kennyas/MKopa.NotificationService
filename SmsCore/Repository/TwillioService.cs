using Microsoft.Extensions.Logging;
using SmsCore.Dto;
using SmsCore.Interface;

namespace SmsCore.Repository
{
    public class TwillioService : ISmsNotification
    {
        ILogger _logger;
        public TwillioService(ILogger<TwillioService> logger) 
        {
            _logger = logger;
        }
        public Task<SmsProviderResponse> SendSMSNotification(string to, string message, string from)
        {
            return Task.FromResult(HttpCallResponse());
        }
        private static SmsProviderResponse HttpCallResponse()
        {
            return new SmsProviderResponse { ResponseCode = "00", ResponseMessage = "success" };

        }
    }
}
