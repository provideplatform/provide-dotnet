using System.Collections.Generic;

namespace provide.Model.GoldMine
{
    public class Bridge: BaseModel
    {
        public string NetworkId { get; set; }
        public string ApplicationId  { get; set; }
        public Dictionary<string, object> Params { get; set; }
    }
}
