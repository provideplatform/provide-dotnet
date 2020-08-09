using System.Collections.Generic;

namespace provide.Model.GoldMine
{
    public class Contract: BaseModel
    {
        public string NetworkId { get; set; }
        public string ContractId { get; set; }
        public string ApplicationId  { get; set; }
        public string TransactionId  { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string AccessedAt { get; set; }
        public Dictionary<string, object> Params { get; set; }
    }
}
