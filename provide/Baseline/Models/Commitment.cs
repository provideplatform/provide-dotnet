using System.Collections.Generic;

namespace provide.Baseline.Model
{
    public class Commitment
    {
        public string Salt { get; set; }
        public string Value { get; set; }
        public int[] Proof { get; set; }
        public string[] PublicInputs { get; set; }
        public Dictionary<string, string> Signatures { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public string Sender { get; set; }
    }
}