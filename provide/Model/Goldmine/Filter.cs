using System;
using System.Collections.Generic;

namespace provide.Model.GoldMine
{
    public class Filter: BaseModel
    {
        public Guid NetworkId { get; set; }
        public Guid ApplicationId  { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Lang { get; set; }
        public string Source { get; set; }
        public Dictionary<string, object> Params { get; set; }
    }
}
