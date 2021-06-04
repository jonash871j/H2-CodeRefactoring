using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CodeRefactoring
{
    public class HostAddresses
    {
        public string URL { get; set; }
        public IPAddress[] IPAddresses { get; set; }

        public HostAddresses(string url)
        {
            URL = url;

            try
            {
                IPAddresses = Dns.GetHostAddresses(url);
            }
            catch
            {
                URL = "InvalidURL.com";
                IPAddresses = Dns.GetHostAddresses("InvalidURL.com");
            }
        }

        public override string ToString()
        {
            string str =  $"HostAddesses for {URL}\n";

            foreach (IPAddress ip in IPAddresses)
            {
                str += ip.ToString() + "\n";
            }

            return str;
        }
    }
}
