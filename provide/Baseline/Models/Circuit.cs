using System.Collections.Generic;

namespace provide.Baseline.Model
{
    public class Circuit
    {
        /// <summary>
        /// Identifier of the circuit; corresponds to the workflow identifier
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Human-readable name for the circuit
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Optional description highlighting the purpose of the
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Type is the proving system of the circuit (i.e., groth16)
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Frontend/backend circuit provider (i.e. zokrates, gnark, etc)
        /// </summary>
        public string Provider { get; set; }
        
        /// <summary>
        /// The curve; i.e. in the case of r1cs, BN256, BW761 etc.
        /// </summary>
        public string Curve { get; set; }
        
        /// <summary>
        /// Optional ABI-like representation of the circuit; this may be renamed to ABI
        /// </summary>
        public string ConstraintSystem { get; set; }
        
        /// <summary>
        /// Arbitrary metadata...
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; }
    }
}
