using System.Collections.Generic;

namespace provide.Baseline.Model
{
    public class Commitment
    {
        public Dictionary<string, object> Metadata { get; set; }
        public int Location { get; set; }
        public string Salt { get; set; }
        public int[] Proof { get; set; }
        public string[] PublicInputs { get; set; }
        public string Sender { get; set; }
        public Dictionary<string, string> Signatures { get; set; }
        public long Timestamp { get; set; } // TODO: int or long
        public string Value { get; set; }
    }
}