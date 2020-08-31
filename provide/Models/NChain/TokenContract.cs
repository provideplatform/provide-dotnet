using Newtonsoft.Json;
using System;

namespace provide.Model.NChain
{
    public class TokenContract: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? NetworkId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ContractId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ApplicationId  { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public string Address { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string AccessedAt { get; set; }

        public int Decimals { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SaleAddress { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? SaleContractId  { get; set; }
    }
}
