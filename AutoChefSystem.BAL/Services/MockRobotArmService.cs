using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.Services.Interfaces;

namespace AutoChefSystem.Services.Services
{
    public class MockRobotArmService : IRobotArmService
    {
        public Task<string> SendCommandAsync(string command)
        {
            return Task.FromResult("Mock response from robot arm.");
        }
    }
}
