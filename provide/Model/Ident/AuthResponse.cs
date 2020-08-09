namespace provide.Model.Ident
{
    public class AuthResponse 
    {
        public User User { get; set; } 
        public JWTToken Token { get; set; }    
    }
}