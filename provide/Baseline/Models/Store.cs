using System.Collections.Generic;

namespace provide.Baseline.Model
{
    public class Store
    {
        public string Identifier { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public string Provider { get; set; }
        public string Url { get; set; }
    }
}
