using System.Collections.Generic;

namespace provide.Baseline.Model
{
    public class Workflow
    {
        /// <summary>
        /// Reference to the underlying circuit.
        /// </summary>
        public Circuit Circuit  { get; set; }

        /// <summary>
        /// Commitments[0] is latest commitment (new commitments are prepended to array).
        /// </summary>
        public Commitment[] Commitments { get; set; }

        /// <summary>
        /// Subset of parties in a workgroup.
        /// </summary>
        public Participant[] Participants { get; set; }

        /// <summary>
        /// Workflow identifier; should match circuit.id
        /// </summary>
        public string Identifier  { get; set; }

        /// <summary>
        /// Shield contract address.
        /// </summary>
        public string Shield  { get; set; }

        /// <summary>
        /// Map of model name to model representing the underlying domain model and its local persistent store (i.e. system of record).
        /// </summary>
        public Dictionary<string, Model> Persistence { get; set; }

        /// <summary>
        /// Arbitrary workflow metadata.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; }
    }
}
