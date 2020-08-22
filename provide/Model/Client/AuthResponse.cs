using provide.Model.Ident;

namespace provide.Model.Client
{
    public class AuthResponse: ProvideResponse
    {
        public User User { get; set; } 
        public JWTToken Token { get; set; }    
    }
}