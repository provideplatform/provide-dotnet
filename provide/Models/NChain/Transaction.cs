
using System;
using System.Collections.Generic;
using System.Numerics;

namespace provide.Model.GoldMine
{
    public class Transaction: BaseModel
    {
        public Guid NetworkId { get; set; }
        public Guid ApplicationId  { get; set; }
        public Guid ContractId  { get; set; }
        public Guid AccountId  { get; set; }
        public Guid UserId  { get; set; }
        public string Signer  { get; set; }
        public string To  { get; set; }
        // Is BigInteger ok here?
        public BigInteger Value  { get; set; }
        public string Data { get; set; }
        public string Hash { get; set; }
        public string Status { get; set; }
        public string Ref { get; set; }
        public string Description { get; set; }
        // check what traces is
        public object Traces { get; set; }
        public int Block { get; set; }
        public string BlockTimestamp { get; set; }
        public string BroadcastAt { get; set; }
        public string FinalizedAt { get; set; }
        public string PublishedAt { get; set; }
        // latency typo?
        public int PublishLatecy { get; set; }
        public int BroadcastLatency { get; set; }
        public int E2eLatency { get; set; }
        public Dictionary<string, object> Params { get; set; }
    }
}
