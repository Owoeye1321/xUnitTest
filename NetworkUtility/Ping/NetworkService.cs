using System;
using System.Net.NetworkInformation;
using NetworkUtility.Dns;

namespace NetworkUtility.Ping
{
	public class NetworkService
	{
        private IDns _dnsService; 
        public NetworkService( IDns _dnsService)
        {
            this._dnsService = _dnsService;
        }
        public string SendPing()
        {
            //sendDns
            var dnsSuccess = _dnsService.sendDns();
            if (dnsSuccess)
            {
                return "Success: Ping Sent!";
            }
            else
            {
                return "Failed!!! Ping Not Sent";
            }
            
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }

        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }
        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }
        public IEnumerable<PingOptions> GetAllPingOptions()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            },
                new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            },new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            },
        };
            return pingOptions;
        }
    }  
}

 