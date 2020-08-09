namespace provide.Model.Vault
{
    public class Secret: BaseModel
    {
        public string VaultId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}