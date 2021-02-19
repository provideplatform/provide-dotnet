using Newtonsoft.Json;
using System;
using System.Numerics;

namespace provide.Model.NChain
{
    public class Account: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid NetworkId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? WalletId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ApplicationId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? UserId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Address  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HdDerivationPath  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PublicKey  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PrivateKey  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public BigInteger Balance  { get; set; }
    }
}
