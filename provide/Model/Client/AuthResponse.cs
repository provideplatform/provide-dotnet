using provide.Model.Ident;

namespace provide.Model.Client
{
    public class AuthResponse
    {
        public User User { get; set; } 
        public JWTToken Token { get; set; }    
    }
}