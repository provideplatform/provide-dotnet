namespace provide.Baseline.Model
{
    public class State
    {
        public string Identifier { get; set; }
        public string Shield { get; set; }
        public Persistence Persistence { get; set; }
        public Participant[] Parties { get; set; }
        public Commitment[] Commitments { get; set; }
    }
}