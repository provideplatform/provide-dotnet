using provide.Model;
using System;

namespace provide.Model.Vault
{
    public class Secret: BaseModel
    {
        public Guid VaultId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
