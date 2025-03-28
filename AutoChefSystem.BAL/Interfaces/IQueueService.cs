﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues;

namespace AutoChefSystem.Services.Interfaces
{
    public interface IQueueService
    {
        Task SendMessageAsync(string message);
        Task<string> ReceiveMessageAsync();
        Task<List<QueueMessage>> ReceiveAllMessagesAsync(int maxMessages);
        Task<bool> DeleteMessageByOrderIdAsync(int orderId);
        Task DeleteMessageAsync(string messageId, string popReceipt);
    }
}
