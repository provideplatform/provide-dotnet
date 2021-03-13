using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace provide.Model.Privacy
{
    public class Circuit: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Artifacts { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Identifier { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Provider { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Curve { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ProvingScheme { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ProvingKeyId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string VerifyingKeyId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> VerifierContract { get; set; }
    }
}
