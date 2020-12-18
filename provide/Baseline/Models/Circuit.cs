using System.Collections.Generic;

namespace provide.Baseline.Model
{
    public class Circuit
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Provider { get; set; }
        public string Curve { get; set; }
        public string ConstraintSystem { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}