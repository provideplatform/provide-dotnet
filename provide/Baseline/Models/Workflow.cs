using System.Collections.Generic;

namespace provide.Baseline.Model
{
    public class Workflow
    {
        public Circuit Circuit  { get; set; }
        public Commitment[] commitments { get; set; }
        public Participant[] Participants { get; set; }
        public string Identifier  { get; set; }
        public string Shield  { get; set; }
        public Dictionary<string, Model> Persistence { get; set; } // TODO: Verify type
        public Dictionary<string, object> Metadata { get; set; }
    }
}
