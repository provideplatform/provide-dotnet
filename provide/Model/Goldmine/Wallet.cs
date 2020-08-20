using System;

namespace provide.Model.GoldMine
{
    public class Wallet: BaseModel
    {
        public Guid WalletId { get; set; }
        public Guid ApplicationId  { get; set; }
        public Guid UserId  { get; set; }
        public string Path  { get; set; }
        public int? Purpose  { get; set; }
        public string Mnemonic  { get; set; }
        public string Seed  { get; set; }
        public string PublicKey  { get; set; }
        public string PrivateKey  { get; set; }
    }
}
