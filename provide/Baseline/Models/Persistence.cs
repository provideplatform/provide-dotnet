using System.Collections.Generic;

namespace provide.Baseline.Model
{
    public class Persistence
    {
        public string Url { get; set; }
        public string Model { get; set; }
        public string Id { get; set; }
        public string[] Fields { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}
