using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace provide.Model.NChain
{
    public class Bridge: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? NetworkId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ApplicationId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Params { get; set; }
    }
}
