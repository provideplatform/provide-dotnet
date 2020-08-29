using System;

namespace provide.Model.Vault
{
    public class Key: BaseModel
    {
        public Guid VaultId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Usage { get; set; }
        public string Spec { get; set; }
        public string PublicKey { get; set; }
        public string Address { get; set; }
    }
}
