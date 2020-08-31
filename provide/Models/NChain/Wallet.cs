using Newtonsoft.Json;
using System;

namespace provide.Model.NChain
{
    public class Wallet: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? WalletId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ApplicationId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? UserId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Address  { get; set; }

        public string Path  { get; set; }

        public int? Purpose  { get; set; }

        public string Mnemonic  { get; set; }

        public string Seed  { get; set; }

        public string PublicKey  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PrivateKey  { get; set; }
    }
}
