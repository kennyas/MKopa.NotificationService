using SmsCore.Dto;

namespace SmsCore.Interface
{
    public interface ISmsNotification
    {
        Task<SmsProviderResponse> SendSMSNotification(string to, string message, string from);
    }
}
