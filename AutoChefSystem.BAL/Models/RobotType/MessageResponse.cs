using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.RobotType
{
    public class MessageResponse<T>
    {
        /// <summary>
        /// Thông báo phản hồi từ API.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Dữ liệu trả về từ API (có thể là null nếu không có dữ liệu).
        /// </summary>
        public T? Data { get; set; }

        public MessageResponse(string message, T? data = default)
        {
            Message = message;
            Data = data;
        }
    }
}
    