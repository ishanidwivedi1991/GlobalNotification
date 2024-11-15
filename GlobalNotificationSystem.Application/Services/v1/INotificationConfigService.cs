using GlobalNotificationSystem.Application.Contracts.v1.Notification;

namespace GlobalNotificationSystem.Application.Services.v1
{
    public interface INotificationConfigService
    {
        public Task<Response> PostValidateNotificationByNumberAsync(Request request);
        public Task<Response> PostValidateNotificationByAccountAsync(Request request);
    }
}
