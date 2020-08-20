using System;
using System.Collections.Generic;

namespace provide.Model.GoldMine
{
    public class Contract: BaseModel
    {
        public Guid NetworkId { get; set; }
        public Guid ContractId { get; set; }
        public Guid ApplicationId  { get; set; }
        public Guid TransactionId  { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string AccessedAt { get; set; }
        public Dictionary<string, object> Params { get; set; }
    }
}
