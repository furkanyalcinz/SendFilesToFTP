using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class SFTPConnectionModel
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } = string.Empty;

        public SFTPConnectionModel(string Host, int Port, string Username, string Password) 
        {
            this.Host = Host;
            this.Port = Port;
            this.Username = Username;
            this.Password = Password;
        }
        public SFTPConnectionModel(string Host, int Port, string Username)
        {
            this.Host = Host;
            this.Port = Port;
            this.Username = Username;
        }
    }
}
