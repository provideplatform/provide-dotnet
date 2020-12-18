using System.Collections.Generic;

namespace provide.Baseline.Model
{
    public class Workgroup
    {
        public string Identifier  { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public Participant[] Participants { get; set; }
        public Dictionary<string, Workflow> Workflows { get; set; } // TODO: Verify type 
    }
}
