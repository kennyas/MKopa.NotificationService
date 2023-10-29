using SmsCore.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsCore.Interface
{
    public interface ISmsNotification
    {
        Task<SmsProviderResponse> SendSMSNotification(string to, string message, string from);
    }
}
