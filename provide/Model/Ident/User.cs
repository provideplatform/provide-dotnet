namespace provide.Model.Ident {
    public class User : BaseModel {
        public string ApplicationId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Permission { get; set; }
        public string PrivacyPolicyAgreedAt { get; set; }
        public string TermsOfServiceAgreedAt { get; set; }
    }
}

