namespace SmsCore.Interface
{
    public interface ISmsStrategyProcessor
    {
        Task<ISmsNotification> GetSmsProviderAsync(string To);
    }
}
