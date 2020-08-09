using System.Collections.Generic;

namespace provide.Model.GoldMine
{
    public class LoadBalancer: BaseModel
    {
        public string NetworkId { get; set; }
        public string ApplicationId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Host { get; set; }
        public string Ipv4 { get; set; }
        public string Ipv6 { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Config { get; set; }
    }
}