using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Services
{
    public class RobotArmService
    {
        private TcpClient _client;
        private NetworkStream _stream;

        public RobotArmService(string ipAddress, int port)
        {
            _client = new TcpClient(ipAddress, port);
            _stream = _client.GetStream();
        }

        public async Task<string> SendCommandAsync(string command)
        {
            byte[] data = Encoding.ASCII.GetBytes(command);
            await _stream.WriteAsync(data, 0, data.Length);

            byte[] buffer = new byte[1024];
            int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
            string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            return response;
        }

        public void Close()
        {
            _stream.Close();
            _client.Close();
        }
    }
}
