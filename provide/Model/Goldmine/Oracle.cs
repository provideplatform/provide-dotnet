using System.Collections.Generic;

namespace provide.Model.GoldMine
{
    public class Oracle: BaseModel
    {
        public string NetworkId { get; set; }
        public string ContractId { get; set; }
        public string ApplicationId  { get; set; }
        public string Name { get; set; }
        public string FeedUrl { get; set; }
        public Dictionary<string, object> Params { get; set; }
    }
}
