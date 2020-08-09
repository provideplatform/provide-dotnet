using System.Collections.Generic;

namespace provide.Model.GoldMine
{
    public class NetworkStats: BaseModel
    {
        public int? Block { get; set; }
        public string ChainId  { get; set; }
        public int? Height { get; set; }
        public int? LastBlockAt { get; set; }
        public int? PeerCount { get; set; }
        public string ProtocolVersion { get; set; }
        public string State { get; set; }
        public bool? Syncing { get; set; }
        public Dictionary<string, object> Meta { get; set; }
    }
}
