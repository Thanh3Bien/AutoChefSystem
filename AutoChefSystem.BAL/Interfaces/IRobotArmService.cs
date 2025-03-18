using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Interfaces
{
    public interface IRobotArmService
    {
        Task<string> SendCommandAsync(string command);
    }
}
