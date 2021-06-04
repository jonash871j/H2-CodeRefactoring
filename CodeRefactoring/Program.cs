using CodeRefactoring;
using System;

namespace DNS
{
    class Program
    {
        static void Main()
        {
            // Makes a local ping to machine
            LocalPinging pingHandler = new LocalPinging();
            Console.WriteLine(pingHandler);

            // Gets url from user
            Console.Write("\nEnter url: ");
            string url = Console.ReadLine();

            // Gets and prints host hostAddresses from url
            HostAddresses hostAddresses = new HostAddresses(url);
            Console.WriteLine(hostAddresses);

            // Gets ip from user
            Console.Write("Enter ip: ");
            string ip = Console.ReadLine();

            // Tests ip address and prints info
            HostHandler hostHandler = new HostHandler(ip);
            Console.WriteLine(hostHandler);

            if (hostHandler.IsSuccessfull()) // If ip address is valid
            {
                // Starts a traceroute to ip
                TracerouteHandler tracerouteHandler = new TracerouteHandler(ip);
                tracerouteHandler.TracerouteLogUpdate += OnLogUpdate;
                tracerouteHandler.Start();
            }
            else
            {
                Console.WriteLine(hostHandler.StatusMsg);
            }

            Console.Write("\nPress any key to continue to local DHCP addresses...");
            Console.ReadKey();

            // Starts a DHCP search on local network
            DHCPServerAddresses dHCPServerAddresses = new DHCPServerAddresses();
            dHCPServerAddresses.DHCPLogUpdate += OnLogUpdate;
            dHCPServerAddresses.Start();

            // Gets and prints local machine host info
            HostInfo hostInfo = new HostInfo();
            Console.WriteLine(hostInfo);

            Console.Write("\nPress any key to end...");
            Console.ReadKey();
        }

        private static void OnLogUpdate(string line)
        {
            Console.WriteLine(line);
        }
    }
}
