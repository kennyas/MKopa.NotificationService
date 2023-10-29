using Microsoft.Extensions.Logging;
using SmsCore.Dto;
using SmsCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private  SmsProviderResponse HttpCallResponse()
        {
            return new SmsProviderResponse { ResponseCode = "00", ResponseMessage = "success" };

        }

    }
}
