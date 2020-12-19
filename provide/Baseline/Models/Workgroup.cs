using System.Collections.Generic;

namespace provide.Baseline.Model
{
    public class Workgroup
    {
        /// <summary>
        /// Optional workgroup identifier.
        /// </summary>
        public string Identifier  { get; set; }

        /// <summary>
        /// Arbitrary workgroup metadata.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Parties to a workgroup.
        /// </summary>
        public Participant[] Participants { get; set; }

        /// <summary>
        /// References to the workflows that are part of the workgroup.
        /// </summary>
        public Dictionary<string, Workflow> Workflows { get; set; } 
    }
}
