using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CodeRefactoring
{
    public class HostInfo
    {
        public string HostName { get; private set; }
        public IPHostEntry IPHostEntry { get; private set; }

        public HostInfo()
            : this(Dns.GetHostName())
        {
        }
        public HostInfo(string hostName)
        {
            HostName = hostName;
            IPHostEntry = Dns.GetHostByName(HostName);
        }
        public string GetAliases()
        {
            string aliases = "\n";
            foreach(string alias in IPHostEntry.Aliases)
            {
                aliases += alias + '\n';
            }
            return aliases;
        }
        public string GetIPAddesses()
        {
            string ipAddresses = "\n";
            foreach (IPAddress ipAddress in IPHostEntry.AddressList)
            {
                ipAddresses += ipAddress.ToString() + '\n';
            }
            return ipAddresses;
        }
        public override string ToString()
        {
            return
                $"Hostname : {HostName}\n" +
                $"* Aliases {GetAliases()}" +
                $"* IP address list {GetIPAddesses()}";
        }
    }
}
