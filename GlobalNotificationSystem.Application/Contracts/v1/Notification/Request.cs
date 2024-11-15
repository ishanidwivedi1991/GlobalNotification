using System.Collections.Generic;

namespace GlobalNotificationSystem.Application.Contracts.v1.Notification
{
    public class Request
    {
        public IEnumerable<Content> Content { get; set; }
        public Contact Sender { get; set; }        
    }

    public class Account
    {
        public string AccountId { get; set; }
        public string AccountName { get; set; }
    }

    public class Contact
    {
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
    }

    public class Content
    {
        public string Body { get; set; }
        public Contact Receiver { get; set; }
        public Account Account { get; set; }
    }

}
