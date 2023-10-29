using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsCore.Interface
{
    public interface ISmsStrategyProcessor
    {
        Task<ISmsNotification> GetSmsProviderAsync(string To);
    }
}
