using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Common.Web
{
    public class IpExt
    {
        public static string GetIpFromHostname(string hostname)
        {
            //  Validar si es un hostname

            string ip = "";
            string noPort = hostname;

            if (noPort.Contains(":"))
            {
                noPort = noPort.Remove(noPort.IndexOf(':'));
            }

            IPAddress address;
            if (IPAddress.TryParse(noPort, out address))
            {
                switch (address.AddressFamily)
                {
                    case System.Net.Sockets.AddressFamily.InterNetwork:
                    case System.Net.Sockets.AddressFamily.InterNetworkV6:
                        ip = hostname;
                        break;

                    default:
                        break;
                }
            }

            if (!string.IsNullOrEmpty(ip))
            {
                return ip;
            }

            //  Obtener IP

            var addresslist = Dns.GetHostAddresses(hostname);
            foreach (var theaddress in addresslist)
            {
                ip = theaddress.ToString();
                break;
            }

            return ip;
        }
    }
}
