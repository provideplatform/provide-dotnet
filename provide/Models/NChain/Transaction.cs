using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace provide.Model.NChain
{
    public class Transaction: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? NetworkId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ApplicationId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ContractId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? AccountId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? UserId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? KeyId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Signer  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string To  { get; set; }

        public BigInteger Value  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Ref { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        // check what traces is
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Traces { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Block { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string BlockTimestamp { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string BroadcastAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FinalizedAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PublishedAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int PublishLatency { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int BroadcastLatency { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int E2eLatency { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] Params { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }
    }
}
