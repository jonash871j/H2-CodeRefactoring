using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;

namespace CodeRefactoring
{
    public class HostHandler
    {
        public string IP { get; private set; }
        public string StatusMsg { get; private set; }
        public IPHostEntry IPHostEntry { get; private set; } 
        public HostHandler(string ip)
        {
            IP = ip;
            IPHostEntry = GetHostByAddress(IP);
        }
        public override string ToString()
        {
            return $"\nHost name for {IP} ---------------\n" +
                    $"Status is: {StatusMsg}\n" +
                    $" Hostname: {(IPHostEntry == null ? "Couldn't be found..." : IPHostEntry.HostName)}";
        }
        public bool IsSuccessfull()
        {
            return StatusMsg == "Succesfull";
        }
        private IPHostEntry GetHostByAddress(string ip)
        {
            try
            {
                StatusMsg = "Succesfull";
                return Dns.GetHostByAddress(ip);
            }
            catch (FormatException)
            {
                StatusMsg = "Please specify a valid IP address.";
            }
            catch (SocketException)
            {
                StatusMsg = "Unable to perform lookup - a socket error occured.";
            }
            catch (SecurityException)
            {
                StatusMsg = "Unable to perform lookup - permission denied.";
            }
            catch (Exception)
            {
                StatusMsg = "An unspecified error occured.";
            }
            return null;
        }
    }
}