using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace provide.Model.Bookie
{
    public class Payment: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string To { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Params { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Result { get; set; }
    }
}
