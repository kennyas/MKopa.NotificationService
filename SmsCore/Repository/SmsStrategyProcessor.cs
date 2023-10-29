using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmsCore.Dto;
using SmsCore.Interface;

namespace SmsCore.Repository
{
    public class SmsStrategyProcessor : ISmsStrategyProcessor
    {
        //private readonly Dictionary<string, ISmsNotification> _strategies = new Dictionary<string, ISmsNotification>();

        private readonly IHttpClientFactory _httpClientFactory;
        private ILogger<SmsStrategyProcessor> _logger;
        private ILogger<TwillioService> _twilioLogger;
        public SmsStrategyProcessor(
            IServiceProvider serviceProvider, ILogger<SmsStrategyProcessor> logger)
        {
            _logger = logger;
            _httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            _strategies.Add("Twillio", new TwillioService(_twilioLogger));
            // _strategies.Add("Termii", new TermiiService(_termiilogger, _httpClientFactory, _termiiOptions));
        }

        public async Task<ISmsNotification> GetSmsProviderAsync(string phoneCode)
        {

            //var (provider, senderId) = CheckPhoneCodeForProvider(phoneCode, configurationList);
            return _strategies["Twillio"] ; 
        }

        //private static (string, string) CheckPhoneCodeForProvider(string firstThreePrefix, SmsPhoneCodeProviderModel[] phoneCodes)
        //{
        //    var provider = phoneCodes.FirstOrDefault(c => c.Code == firstThreePrefix.Substring(0, 4)
        //                                                 || c.Code == firstThreePrefix.Substring(0, 3)
        //                                                 || c.Code == firstThreePrefix.Substring(0, 2));
        //    return (provider?.Provider, provider?.From);
        //}
        private readonly Dictionary<string, ISmsNotification> _strategies = new Dictionary<string, ISmsNotification>();
    }
}
