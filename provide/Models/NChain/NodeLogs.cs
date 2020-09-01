namespace provide.Model.NChain
{
    public class NodeLogs: BaseModel
    {
        public string[] Logs { get; set; }
        public string PrevToken  { get; set; }
        public string NextToken { get; set; }
    }
}
