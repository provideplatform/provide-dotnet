using Newtonsoft.Json;

namespace provide.Model.Client.ProvideError
{
    [JsonConverter(typeof(ProvideErrorConverter))]
    public class ProvideError
    {
        public Error[] Errors { get; set; }

        public static ProvideError FormatError(string content)
        {
            try
            {
                return JsonConvert.DeserializeObject<ProvideError>(content);
            }
            catch (JsonException)
            {
                Error[] errors = { new Error { Message = content }};
                return new ProvideError
                {
                    Errors = errors
                };
            }
        }
    }
}