using System;

namespace provide.Model.NChain
{
    public class ContractExecution: BaseModel
    {  
        public string Confidence { get; set; }

        public Guid Ref { get; set; }

        public object Response { get; set; }
    }
}
