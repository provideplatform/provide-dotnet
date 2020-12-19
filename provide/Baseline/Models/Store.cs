using System.Collections.Generic;

namespace provide.Baseline.Model
{
    public class Store
    {
        /// <summary>
        /// Optional system of record identifier (i.e. document name, UUID or primary key of relational record).
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Arbitrary metadata.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// The system of record persistence provider. 
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Url referencing the local system of record (i.e. DSN in the case of relational SQL database).
        /// </summary>
        public string Url { get; set; }
    }
}
