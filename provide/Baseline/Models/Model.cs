namespace provide.Baseline.Model
{
    public class Model
    {
        /// <summary>
        /// TODO
        /// </summary>
        public Store Store { get; set; }

        /// <summary>
        /// Name of the application-specific record type (i.e. collection, table).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of fields and/or selectors (regex) within documents/stream to be baselined.
        /// </summary>
        public string[] Fields { get; set; }
    }
}
