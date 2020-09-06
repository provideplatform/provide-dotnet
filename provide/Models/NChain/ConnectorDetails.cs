using Newtonsoft.Json;

namespace provide.Model.NChain
{
    public class ConnectorDetails
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Page { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Rpp { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }
    }
}