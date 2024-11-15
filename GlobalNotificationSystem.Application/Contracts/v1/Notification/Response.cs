using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalNotificationSystem.Application.Contracts.v1.Notification
{
    public class Response
    {
        public bool IsMaxLimitReached { get; set; }
        public int MessageCount { get; set; }   

    }
}
