using System.Collections.Generic;
using Newtonsoft.Json;

namespace provide.Model.Vault
{
    public class SignMessageRequest: BaseModel // FIXME -- this does not need to be a BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Options { get; set; }
    }
}
