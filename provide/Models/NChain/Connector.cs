using System;
using Newtonsoft.Json;

namespace provide.Model.NChain
{
    public class Connector: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid NetworkId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid Applicationid { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid Organizationid { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string AccessedAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Node[] Nodes { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ConnectorDetails Details { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public LoadBalancer[] LoadBalancers { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ConnectorConfig Config { get; set; }
    }
}
  