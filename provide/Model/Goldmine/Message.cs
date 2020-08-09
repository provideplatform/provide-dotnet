namespace provide.Model.GoldMine
{
    public class Message: BaseModel
    {
        public MessageData Data { get; set; }
        public string Sender  { get; set; }
        public string Timestamp { get; set; }
        public Transaction Tx { get; set; }
    }
}
