using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace provide.Model.NChain
{
    public class Node: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? NetworkId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ApplicationId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? UserId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? Bootnode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Host { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Ipv4 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Ipv6 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PrivateIpv4 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PrivateIpv6 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Role { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Config { get; set; }
    }
}
