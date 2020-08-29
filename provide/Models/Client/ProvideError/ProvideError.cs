using Newtonsoft.Json;
using provide.Model;

namespace provide.Model.Client.ProvideError
{
    [JsonConverter(typeof(ProvideErrorConverter))]
    public class ProvideError
    {
        public ProvideError[] Errors { get; set; }

        public static ProvideError FormatError(string content)
        {
            try
            {
                return JsonConvert.DeserializeObject<ProvideError>(content);
            }
            catch (JsonException)
            {
                ProvideError[] errors = { new ProvideError()} ;
                return new ProvideError
                {
                    Errors = errors
                };
            }
        }
    }
}
