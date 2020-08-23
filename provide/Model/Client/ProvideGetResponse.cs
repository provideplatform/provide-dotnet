using Newtonsoft.Json;

namespace provide.Model.Client
{
    [JsonObject]
    public class ProvideGetResponse<BaseModel>: ProvideResponse
    {
        [JsonProperty("Response")]
        public BaseModel Response { get; set;}
    }
}
