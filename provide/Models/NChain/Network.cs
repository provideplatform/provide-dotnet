using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace provide.Model.NChain
{
    public class Network: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? NetworkId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ApplicationId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? UserId  { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int ChainId { get; set; }

        public NetworkStats Stats { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Config { get; set; }
    }
}
