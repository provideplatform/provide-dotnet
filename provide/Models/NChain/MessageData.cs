namespace provide.Model.NChain
{
    public class MessageData: BaseModel
    {
        public string DataUrl { get; set; }

        public string Hash  { get; set; }

        public string ModifiedAt { get; set; }

        public int? Size { get; set; }

        public string Filename { get; set; }

        public string Type { get; set; }
    }
}
