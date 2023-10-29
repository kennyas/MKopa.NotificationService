using Microsoft.Extensions.Logging;
using SmsCore.Interface;

namespace SmsCore.Repository
{
    public class SmsStrategyProcessor : ISmsStrategyProcessor
    {
        private readonly Dictionary<string, ISmsNotification> _strategies = new();
        private readonly ILogger<SmsStrategyProcessor> _logger;
        private readonly ILogger<TwillioService> _twilioLogger;
        public SmsStrategyProcessor(ILogger<SmsStrategyProcessor> logger)
        {
            _logger = logger;
            _strategies.Add("Twillio", new TwillioService(_twilioLogger));
        }

        public async Task<ISmsNotification> GetSmsProviderAsync(string phoneCode)
        {
            //var (provider, senderId) = CheckPhoneCodeForProvider(phoneCode, configurationList);
            return _strategies["Twillio"] ; 
        }        
    }
}