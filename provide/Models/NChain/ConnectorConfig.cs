using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace provide.Model.NChain
{
    public class ConnectorConfig
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Container { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Credentials { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Env { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid EngineId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid ProviderId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Role { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid TargetId { get; set; }
    }
}
