using System;
using System.Collections.Generic;

namespace provide.Model.GoldMine
{
    public class Oracle: BaseModel
    {
        public Guid NetworkId { get; set; }
        public Guid ContractId { get; set; }
        public Guid ApplicationId  { get; set; }
        public string Name { get; set; }
        public string FeedUrl { get; set; }
        public Dictionary<string, object> Params { get; set; }
    }
}
