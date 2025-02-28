using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AutoChefSystem.Services.Services
{
    public class PushNotificationService
    {
        private readonly string _serverKey = "BFygdt6WJd9JbmJ1cDVYc7oslJXs5SCUEZyXwI26GrHzOXvGYInKSKgq-Er1xxPtlHBww-2a1t7gUKowQxafiHI";
        private readonly string _fcmUrl = "https://fcm.googleapis.com/fcm/send";
        public async Task SendPushNotification(string deviceToken, string title, string message)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("key", "=" + _serverKey);

                var payload = new
                {
                    to = deviceToken,
                    notification = new
                    {
                        title = title,
                        body = message
                    }
                };

                var jsonPayload = JsonConvert.SerializeObject(payload);
                var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(_fcmUrl, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Push notification sent successfully.");
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Failed to send push notification. Status code: {response.StatusCode}, Response: {errorResponse}");
                }
            }
        }

    }
}
