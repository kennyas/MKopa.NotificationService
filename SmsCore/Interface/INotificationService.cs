namespace SmsCore.Interface
{
    public interface INotificationService
    {
        Task SendSmsAsync(string ClientRequestId, string To, string MessageBody);
    }
}
