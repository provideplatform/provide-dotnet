namespace provide.Model.Ident
{
    public class Organization: BaseModel
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public int? Permissions { get; set; }
        public User[] Users { get; set; }
    }
}