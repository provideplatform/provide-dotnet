using System;

namespace provide.Model.GoldMine
{
    public class Account: BaseModel
    {
        public Guid NetworkId { get; set; }
        public Guid WalletId { get; set; }
        public Guid ApplicationId  { get; set; }
        public Guid UserId  { get; set; }
        public string Address  { get; set; }
        public string HdDerivationPath  { get; set; }
        public string PublicKey  { get; set; }
        public string PrivateKey  { get; set; }
    }
}
