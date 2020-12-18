using System.Collections.Generic;

namespace provide.Baseline.Model
{
    public class Participant
    {
        /// <summary>
        /// Public address of the participant.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Arbitrary metadata.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Optional url.
        /// </summary>
        public string Url { get; set; }
    }
}

