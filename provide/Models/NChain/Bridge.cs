using System;
using System.Collections.Generic;

namespace provide.Model.GoldMine
{
    public class Bridge: BaseModel
    {
        public Guid NetworkId { get; set; }
        public Guid ApplicationId  { get; set; }
        public Dictionary<string, object> Params { get; set; }
    }
}
