using Newtonsoft.Json;
using System;

namespace provide.Model.Vault
{
    public class Key: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? VaultId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Usage { get; set; }

        public string Spec { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        public string PublicKey { get; set; }
    }
}
