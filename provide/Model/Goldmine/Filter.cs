using System.Collections.Generic;

namespace provide.Model.GoldMine
{
    public class Filter: BaseModel
    {
        public string NetworkId { get; set; }
        public string ApplicationId  { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Lang { get; set; }
        public string Source { get; set; }
        public Dictionary<string, object> Params { get; set; }
    }
}
