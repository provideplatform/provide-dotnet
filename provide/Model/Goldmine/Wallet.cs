namespace provide.Model.GoldMine
{
    public class Wallet: BaseModel
    {
        public string WalletId { get; set; }
        public string ApplicationId  { get; set; }
        public string UserId  { get; set; }
        public string Path  { get; set; }
        public int? Purpose  { get; set; }
        public string Mnemonic  { get; set; }
        public string Seed  { get; set; }
        public string PublicKey  { get; set; }
        public string PrivateKey  { get; set; }
    }
}
