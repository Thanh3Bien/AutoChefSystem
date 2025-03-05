using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.Users
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string? Image { get; set; }
        public string RoleName { get; set; }
    }
}
