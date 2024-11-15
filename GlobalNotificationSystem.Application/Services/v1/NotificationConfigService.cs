using GlobalNotificationSystem.Application.Contracts.v1.Notification;
using Newtonsoft.Json;

namespace GlobalNotificationSystem.Application.Services.v1
{
    public class NotificationConfigService : INotificationConfigService
    {
        private readonly HttpClient _httpClient;
        private readonly string uri = "https://a4735a7dfbcb49bda4e55dc4cc01e1b5.api.mockbin.io/";

        public NotificationConfigService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<Response> PostValidateNotificationByNumberAsync(Request request)
        {
            Response notitification = new Response() { IsMaxLimitReached = false, MessageCount = request.content.Count()};
            var responseString = await _httpClient.GetStringAsync(uri);
            var providerLimitResponse = JsonConvert.DeserializeObject<ProviderResponse>(responseString);

            var result = from p in request.Content
                         group p by p.Receiver.PhoneNumber into g
                         select new {key = g.Key, cnt = g.Count() };

            //TODO: check if the providerResponse is not null
            if (result.Any(p => p.cnt > Int32.Parse(providerLimitResponse?.limitByPhoneNumber)))
            {
                notitification.IsMaxLimitReached = true;
            }
            else notitification.IsMaxLimitReached = false;

            return notitification;
        }

        public async Task<Response> PostValidateNotificationByAccountAsync(Request request)
        {
            Response notitification = new Response() { IsMaxLimitReached = false, MessageCount = request.content.Count() };

            var responseString = await _httpClient.GetStringAsync(uri);
            var providerLimitResponse = JsonConvert.DeserializeObject<ProviderResponse>(responseString);

            var result = from p in request.Content
                         group p by p.Account.AccountId into g
                         select new { key = g.Key, cnt = g.Count() };

            //TODO: Fix null reference error
            if (result.Any(p => p.cnt > Int32.Parse(providerLimitResponse?.limitByAccount)))
            {
                notitification.IsMaxLimitReached = true;
            }
            else notitification.IsMaxLimitReached = false;
            
            
            return notitification;
        }
    }
}
