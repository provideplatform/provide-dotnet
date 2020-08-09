namespace provide.Model.Ident
{
    public class JWTToken
    {
        public string Id { get; set; } 
        public string AccessToken { get; set; } 
        public int ExpiresIn { get; set; } 
        public string Token { get; set; } 
        public int? Permissions { get; set; } 
    }
}