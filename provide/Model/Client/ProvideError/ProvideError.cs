using Newtonsoft.Json;

namespace provide.Model.Client.ProvideError
{
    [JsonConverter(typeof(ProvideErrorConverter))]
    public class ProvideError
    {
        public Error[] Errors { get; set; }
    }
}