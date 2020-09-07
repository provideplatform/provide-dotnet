using System.Collections.Generic;
using Newtonsoft.Json;

namespace provide.Model.NChain
{
    public class ConnectedEntity: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DataURL  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Type  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Href { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ModifiedAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FileName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Raw { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Size { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ConnectedEntity Parent { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ConnectedEntity[] Children { get; set; }
    }
}
