using System.Collections.Generic;

namespace provide.Model.GoldMine
{
    public class Node: BaseModel
    {
        public string NetworkId { get; set; }
        public string ApplicationId { get; set; }
        public string UserId { get; set; }
        public bool? Bootnode { get; set; }
        public string Host { get; set; }
        public string Ipv4 { get; set; }
        public string Ipv6 { get; set; }
        public string PrivateIpv4 { get; set; }
        public string PrivateIpv6 { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Config { get; set; }
    }
}
