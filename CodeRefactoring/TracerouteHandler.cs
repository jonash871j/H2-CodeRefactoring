using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace CodeRefactoring
{
    public class TracerouteHandler
    {
        private const int MAX_HOPS = 30;
        private const int TIME_OUT = 1000;

        public IPAddress IpAddress { get; private set; }
        public event LogEventHandler TracerouteLogUpdate;

        public TracerouteHandler(string ipAddress)
        {
            IpAddress = IPAddress.Parse(ipAddress);
        }

        public void Start()
        {
            TracerouteLogUpdate?.Invoke($"\nTracerouting to {IpAddress} ---------------");

            using (Ping pingSender = new Ping())
            {
                PingOptions pingOptions = new PingOptions(1, true);
                Stopwatch stopWatch = new Stopwatch();

                TracerouteLogUpdate?.Invoke(string.Format(
                        "Maximum of {1} hops:",
                        IpAddress,
                        MAX_HOPS));

                for (int i = 1; i < MAX_HOPS + 1; i++)
                {
                    stopWatch.Reset();
                    stopWatch.Start();

                    PingReply pingReply = pingSender.Send(
                        IpAddress,
                        TIME_OUT,
                        new byte[32], pingOptions);

                    stopWatch.Stop();

                    TracerouteLogUpdate?.Invoke(
                        string.Format("{0}\t{1} ms\t{2} \t{3}",
                        i,
                        stopWatch.ElapsedMilliseconds,
                        pingReply.Address,
                        pingReply.Status));

                    if (pingReply.Status == IPStatus.Success)
                    {
                        TracerouteLogUpdate?.Invoke("\nTraceroute complete"); 
                        break;
                    }

                    pingOptions.Ttl++;
                }
            }
        }
    }
}
