namespace provide.Model.GoldMine
{
    public class Account: BaseModel
    {
        public string NetworkId { get; set; }
        public string WalletId { get; set; }
        public string ApplicationId  { get; set; }
        public string UserId  { get; set; }
        public string Address  { get; set; }
        public string HdDerivationPath  { get; set; }
        public string PublicKey  { get; set; }
        public string PrivateKey  { get; set; }
    }
}
