using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsCore.Interface
{
    public interface INotificationService
    {
        Task SendSmsAsync(string ClientRequestId, string To, string MessageBody);
    }
}
