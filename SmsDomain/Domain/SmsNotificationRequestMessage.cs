namespace SmsDomain.Domain
{
    public class SmsNotificationRequestMessage
    {
        public string MessageBody { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string ClientRequestId { get; set; } = string.Empty;
    }
}
