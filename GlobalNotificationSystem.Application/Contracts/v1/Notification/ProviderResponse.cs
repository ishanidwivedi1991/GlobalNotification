using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalNotificationSystem.Application.Contracts.v1.Notification
{
    public class ProviderResponse
    {
        public string limitByPhoneNumber { get; set; }
        public string limitByAccount { get; set; }
    }
}
