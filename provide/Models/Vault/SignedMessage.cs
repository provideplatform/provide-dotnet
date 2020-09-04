using Newtonsoft.Json;

namespace provide.Model.Vault
{
    // FIXME: type name probably can be better
    public class SignedMessage: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Signature { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? Verified { get; set; }
    }
}
