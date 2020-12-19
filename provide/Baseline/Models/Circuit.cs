using System.Collections.Generic;

namespace provide.Baseline.Model
{
    public class Circuit
    {
        /// <summary>
        /// TODO
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// TODO
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// TODO
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// TODO
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// TODO
        /// </summary>
        public string Provider { get; set; }
        
        /// <summary>
        /// TODO
        /// </summary>
        public string Curve { get; set; }
        
        /// <summary>
        /// TODO
        /// </summary>
        public string ConstraintSystem { get; set; }
        
        /// <summary>
        /// TODO
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; }
    }
}