using System;

namespace provide.Model.Vault
{
    public class Vault: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid MasterKeyId { get; set; }
    }
}
