using Newtonsoft.Json;

namespace provide.Model.Vault
{
    public class SignatureVerificationResponse: BaseModel // FIXME -- this does not need to be a BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool Verified { get; set; }
    }
}
