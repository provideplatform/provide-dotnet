using System.Collections.Generic;

namespace provide.Model.GoldMine
{
    public class Network: BaseModel
    {
        public string NetworkId { get; set; }
        public string ApplicationId  { get; set; }
        public string UserId  { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public string ChainId { get; set; }
        public NetworkStats Stats { get; set; }
        public Dictionary<string, object> Config { get; set; }
    }
}
