using System;
using System.Collections.Generic;

namespace provide.Model.GoldMine
{
    public class Network: BaseModel
    {
        public Guid NetworkId { get; set; }
        public Guid ApplicationId  { get; set; }
        public Guid UserId  { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public Guid ChainId { get; set; }
        public NetworkStats Stats { get; set; }
        public Dictionary<string, object> Config { get; set; }
    }
}
