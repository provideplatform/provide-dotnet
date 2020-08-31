using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace provide.Model.NChain
{
    public class Filter: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? NetworkId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ApplicationId  { get; set; }

        public string Name { get; set; }

        public int Priority { get; set; }

        public string Lang { get; set; }

        public string Source { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Params { get; set; }
    }
}
