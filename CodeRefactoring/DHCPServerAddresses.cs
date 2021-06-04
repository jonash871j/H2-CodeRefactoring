using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace CodeRefactoring
{
    public class DHCPServerAddresses
    {
        public event LogEventHandler DHCPLogUpdate;

        public void Start()
        {
            DHCPLogUpdate?.Invoke("\nDHCP Servers --------------------------\n");
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapteradapterProperties = adapter.GetIPProperties();
                IPAddressCollection addresses = adapteradapterProperties.DhcpServerAddresses;
                
                if (addresses.Count > 0)
                {
                    DHCPLogUpdate?.Invoke(adapter.Description);
                    
                    foreach (IPAddress address in addresses)
                    {
                        DHCPLogUpdate?.Invoke($"DHCP Address ............................ : {address}\n");
                    }
                }
            }
        }
    }
}
