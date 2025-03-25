using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using AutoChefSystem.Services.Interfaces;
using Newtonsoft.Json;

namespace AutoChefSystem.Services.Services
{
    public class QueueService : IQueueService
    {
        private readonly QueueClient _queueClient;

        public QueueService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AzureStorageQueue");
            _queueClient = new QueueClient(connectionString, "autochefqueue");
            _queueClient.CreateIfNotExists(); // Tạo hàng đợi nếu nó chưa tồn tại
        }

        public async Task SendMessageAsync(string message)
        {
            await _queueClient.SendMessageAsync(Convert.ToBase64String(Encoding.UTF8.GetBytes(message)));
        }

        public async Task<string> ReceiveMessageAsync()
        {
            // Nhận tin nhắn từ hàng đợi
            QueueMessage[] messages = await _queueClient.ReceiveMessagesAsync(1);
            if (messages.Length > 0)
            {
                var message = messages[0];
                // Xóa tin nhắn sau khi đã xử lý
                await _queueClient.DeleteMessageAsync(message.MessageId, message.PopReceipt);
                return Encoding.UTF8.GetString(Convert.FromBase64String(message.MessageText));
            }
            return null; // Không có tin nhắn nào
        }


        public async Task<List<QueueMessage>> ReceiveAllMessagesAsync(int maxMessages)
        {
            QueueMessage[] messages = await _queueClient.ReceiveMessagesAsync(maxMessages);
            return messages.ToList();
        }

        public async Task<bool> DeleteMessageByOrderIdAsync(int orderId)
        {
            var messages = await ReceiveAllMessagesAsync(32); 

            foreach (var queueMessage in messages)
            {
                string decodedMessage = Encoding.UTF8.GetString(Convert.FromBase64String(queueMessage.MessageText));
                var orderMessage = JsonConvert.DeserializeObject<dynamic>(decodedMessage);

                if (orderMessage != null && orderMessage.OrderId != null && (int)orderMessage.OrderId == orderId)
                {
     
                    await DeleteMessageAsync(queueMessage.MessageId, queueMessage.PopReceipt);
                    return true; 
                }
            }

            return false; 
        }

        public async Task DeleteMessageAsync(string messageId, string popReceipt)
        {
            await _queueClient.DeleteMessageAsync(messageId, popReceipt);
        }
    }
}
