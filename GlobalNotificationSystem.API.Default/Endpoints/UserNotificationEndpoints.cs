using GlobalNotificationSystem.Application.Contracts.v1.Notification;
using GlobalNotificationSystem.Application.Services.v1;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;

namespace GlobalNotificationSystem.API.Default.Endpoints
{
    public static class UserNotificationEndpoints
    {
        public static void MapNotificationEndpoints(this WebApplication app)
        {
            app.MapPost("/v1/notification/contact/", PostValidateNotificationByNumber);
            app.MapPost("/v1/notification/account/", PostValidateNotificationByAccount);
            app.MapPost("/v1/notification/validate/", PostValidateNotification);
        }

        public static void AddNotificationServices(this IServiceCollection service)
        {
            service.AddHttpClient<INotificationConfigService, NotificationConfigService>();
        }

        internal static Response PostValidateNotificationByNumber(INotificationConfigService service, [FromBody] Request notification)
        {
            return service.PostValidateNotificationByNumberAsync(notification).Result;            
        }

        internal static Response PostValidateNotificationByAccount(INotificationConfigService service, [FromBody] Request notification)
        {
            return service.PostValidateNotificationByAccountAsync(notification).Result;
        }

        internal static Response PostValidateNotification(INotificationConfigService service, [FromBody] Request notification)
        {
            Response result = new Response() { IsMaxLimitReached = false, MessageCount = notification.Content.Count() };

            var responseByNumber = PostValidateNotificationByNumber(service, notification);
            var responseByAccount = PostValidateNotificationByAccount(service, notification);

            if (responseByNumber.IsMaxLimitReached || responseByAccount.IsMaxLimitReached)
            {
                result.IsMaxLimitReached = true;
            }

            return result;

        }
    }
}
