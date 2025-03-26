﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.RobotOperationLog
{
    public class MessageResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }

        public MessageResponse(string message, T data)
        {
            Message = message;
            Data = data;
        }
    }
}
