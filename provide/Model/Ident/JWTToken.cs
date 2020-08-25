namespace provide.Model.Ident
{
    public class JWTToken
    {
        public string Token { get; set; } 
        public string AccessToken { get; set; } 
        public string Kid { get; set; } 
        public string Audience { get; set; } 
        public string Issuer { get; set; } 
        public string IssuedAt { get; set; } 
        public string ExpiresAt { get; set; } 
        public string Subject { get; set; } 
        // prvd and nats
        public int Permissions { get; set; }
    }
}