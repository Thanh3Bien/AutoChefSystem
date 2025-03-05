using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.BAL.Models.Users
{
    public class CreateUserRequest
    {
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int? RoleId { get; set; }
        public string? UserImage { get; set; }
    }
}
