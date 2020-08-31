using Newtonsoft.Json;
using System;

namespace provide.Model
{
    public class BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; set; }
    }
}
