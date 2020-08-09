namespace provide.Model.GoldMine
{
    public class TokenContract: BaseModel
    {
        public string NetworkId { get; set; }
        public string ContractId { get; set; }
        public string ApplicationId  { get; set; }
        public string SaleContractId  { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Address { get; set; }
        public string AccessedAt { get; set; }
        public int Decimals { get; set; }
        public string SaleAddress { get; set; }
    }
}
