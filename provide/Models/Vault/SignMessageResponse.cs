using Newtonsoft.Json;

namespace provide.Model.Vault
{
    public class SignMessageResponse: BaseModel // FIXME -- this does not need to be a BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Signature { get; set; }
    }
}
