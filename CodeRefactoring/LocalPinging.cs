using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace CodeRefactoring
{
    public class LocalPinging
   {
        public PingReply PingReply { get; set; }

        public LocalPinging()
        {
            StartLocalPinging();
        }

        /// <summary>
        /// Used to ping the local machine
        /// </summary>
        private void StartLocalPinging()
        {
            Ping pingSender = new Ping();
            IPAddress address = IPAddress.Loopback;
            PingReply = pingSender.Send(address);
        }

        public override string ToString()
        {
            if (PingReply.Status == IPStatus.Success)
            {
                return $"LocalPinging Status -----------------\n" +
                    $"       Address: {PingReply.Address}\n" +
                    $"RoundTrip time: {PingReply.RoundtripTime}\n" +
                    $"  Time to live: {PingReply.Options.Ttl}\n" +
                    $"Don't fragment: {PingReply.Options.DontFragment}\n" +
                    $"   Buffer size: {PingReply.Buffer.Length}";
            }
            else
            {
                return PingReply.Status.ToString();
            }
        }
    }
}
