using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsDomain.Domain
{
    public class SmsNotificationRequestMessage
    {
        public string MessageBody { get; set; }
        public string PhoneNumber { get; set; }
        public string ClientRequestId { get; set; }
    }
}
